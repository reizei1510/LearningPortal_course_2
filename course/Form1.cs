using System.Net;
using System.Net.Sockets;
using Npgsql;
using System.Xml.Linq;

namespace course
{
    public partial class Form_Tasks : Form
    {
        readonly int id = 0;
        int trying = 0;
        string[] generated_complexity = { "", "", "", "", "" };
        string[] generated_options = { "", "", "", "", "" };
        bool[] results = { false, false, false, false, false };
        bool[] results1 = { false, false, false, false, false };
        bool[] results2 = { false, false, false, false, false };
        bool[] results3 = { false, false, false, false, false };
        bool answers_checked = false;

        NpgsqlConnection conn;
        private string connString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=123;Database=results";
        NpgsqlDataReader reader;

        public Form_Tasks()
        {
            InitializeComponent();

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    id = (int.Parse(ip.ToString().Replace(".", "")) ^ key.k) / 10;

            conn = new NpgsqlConnection(connString);

            //Delete_Student();
            //Recreate_Data_Base();
            Generate_Var();
        }

        internal void Generate_Var()
        {
            rtb_Tasks.Text = "";
            generated_complexity = new string[] { "", "", "", "", "" };

            if (trying == 0)
            {
                trying = Find_Last_Trying();
                if (trying == 0)
                {
                    generated_complexity = new string[] { "1", "1", "1", "1", "1" };
                    Generate_Tasks();
                    return;
                }
                Find_Last_Results("3", results3);
                Find_Last_Results("2", results2);
                Find_Last_Results("1", results1);
            }

            for (int i = 0; i < 5; i++)
                generated_complexity[i] = (results3[i] == true) ? "3" : "";

            Generate_Similar_Var("2", results2);
            Generate_Similar_Var("1", results1);

            for (int i = 0; i < 5; i++)
                if (generated_complexity[i] == "")
                    generated_complexity[i] = "1";

            Generate_Tasks();
        }

        private int Find_Last_Trying()
        {
            int t, trying = 0;

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM complexity_3 WHERE student = @student", conn);
            cmd.Parameters.AddWithValue("@student", id);
            if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
            {
                cmd = new NpgsqlCommand("SELECT MAX(trying) FROM complexity_3 WHERE student = @student", conn);
                cmd.Parameters.AddWithValue("@student", id);
                t = Convert.ToInt32(cmd.ExecuteScalar());
                if (t > trying)
                    trying = t;
            }

            cmd = new NpgsqlCommand("SELECT COUNT(*) FROM complexity_2 WHERE student = @student", conn);
            cmd.Parameters.AddWithValue("@student", id);
            if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
            {
                cmd = new NpgsqlCommand("SELECT MAX(trying) FROM complexity_2 WHERE student = @student", conn);
                cmd.Parameters.AddWithValue("@student", id);
                t = Convert.ToInt32(cmd.ExecuteScalar());
                if (t > trying)
                    trying = t;
            }

            cmd = new NpgsqlCommand("SELECT COUNT(*) FROM complexity_1 WHERE student = @student", conn);
            cmd.Parameters.AddWithValue("@student", id);
            if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
            {
                cmd = new NpgsqlCommand("SELECT MAX(trying) FROM complexity_1 WHERE student = @student", conn);
                cmd.Parameters.AddWithValue("@student", id);
                t = Convert.ToInt32(cmd.ExecuteScalar());
                if (t > trying)
                    trying = t;
            }

            conn.Close();
            return trying;
        }

        private void Find_Last_Results(string k, bool[] resultsk)
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT * FROM complexity_{k} WHERE student = @student AND trying = @trying", conn);
            cmd.Parameters.AddWithValue("@student", id);
            cmd.Parameters.AddWithValue("@trying", trying);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                for (int i = 0; i < 5; i++)
                    resultsk[i] = Convert.ToBoolean(reader.GetValue(i + 2));
            reader.Close();
            conn.Close();
        }

        private void Generate_Similar_Var(string k, bool[] resultsk)
        {
            (double, int, int)[] sims = { (0.0, 0, 0), (0.0, 0, 0), (0.0, 0, 0) };
            bool[] res_sim = { false, false, false, false, false };

            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT COUNT(*) FROM complexity_{k} WHERE student = @student", conn);
            cmd.Parameters.AddWithValue("@student", id);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count != 0)
            {
                cmd = new NpgsqlCommand($"SELECT * FROM complexity_{k}", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < 5; i++)
                        res_sim[i] = Convert.ToBoolean(reader.GetValue(i + 2));
                    double index = Jaccard_Index(resultsk, res_sim);
                    if (Convert.ToInt32(reader.GetValue(1)) != id && index > sims[0].Item1)
                    {
                        sims[0] = (index, Convert.ToInt32(reader.GetValue(1)), Convert.ToInt32(reader.GetValue(7)));
                        sims = sims.OrderBy(x => x.Item1).ToArray();
                    }
                }
                reader.Close();

                Random r = new Random();
                int rand = r.Next(sims.Length);
                cmd = new NpgsqlCommand($"SELECT * FROM complexity_{int.Parse(k) + 1} WHERE student = @student AND trying = @trying", conn);
                cmd.Parameters.AddWithValue("@student", sims[rand].Item2);
                cmd.Parameters.AddWithValue("@trying", sims[rand].Item3 + 1);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    for (int i = 0; i < 5; i++)
                        res_sim[i] = Convert.ToBoolean(reader.GetValue(i + 2));
                reader.Close();

                for (int i = 0; i < 5; i++)
                {
                    if (generated_complexity[i] == "" && res_sim[i] == true)
                        generated_complexity[i] = (int.Parse(k) + 1).ToString();
                }
            }

            conn.Close();
        }

        private double Jaccard_Index(bool[] res1, bool[] res2)
        {
            int n = 0;
            for (int i = 0; i < 5; i++)
                if (res1[i] == res2[i])
                    n++;

            return Convert.ToDouble(n) / Convert.ToDouble(res1.Length + res2.Length - n);
        }

        private void Generate_Tasks()
        {
            XDocument xDoc = XDocument.Load("tasks.xml");
            if (xDoc != null)
            {
                Random r = new Random();
                for (int i = 0; i < 5; i++)
                {
                    generated_options[i] = (r.Next(3) + 1).ToString();
                    var task = xDoc.Element("tasks")?
                                .Elements("var")
                                .Where(p => p.Attribute("complexity")?.Value == generated_complexity[i]
                                && p.Attribute("option")?.Value == generated_options[i])
                                .Elements("task")
                                .Where(p => p.Attribute("num")?.Value == (i + 1).ToString())
                                .Elements("text");
                    if (task != null)
                        foreach (var item in task)
                            rtb_Tasks.Text += $"{i + 1}. {item.Value}\n\n";
                }
            }
            else
                rtb_Tasks.Text = "Задания не найдены.";

            Show_Status();
        }

        private void btn_CheckAnswers_Click(object sender, EventArgs e)
        {
            answers_checked = true;
            label6.Text = "";

            results[0] = Check_Answer(tb_Task1.Text, 1);
            if (results[0])
                panel1.BackColor = Color.Lime;
            else
                panel1.BackColor = Color.Red;

            results[1] = Check_Answer(tb_Task2.Text, 2);
            if (results[1])
                panel2.BackColor = Color.Lime;
            else
                panel2.BackColor = Color.Red;

            results[2] = Check_Answer(tb_Task3.Text, 3);
            if (results[2])
                panel3.BackColor = Color.Lime;
            else
                panel3.BackColor = Color.Red;

            results[3] = Check_Answer(tb_Task4.Text, 4);
            if (results[3])
                panel4.BackColor = Color.Lime;
            else
                panel4.BackColor = Color.Red;

            results[4] = Check_Answer(tb_Task5.Text, 5);
            if (results[4])
                panel5.BackColor = Color.Lime;
            else
                panel5.BackColor = Color.Red;

            Show_Status();
        }

        private bool Check_Answer(string answer, int num)
        {
            XDocument xDoc = XDocument.Load("tasks.xml");
            if (xDoc != null)
            {
                var task = xDoc.Element("tasks")?
                            .Elements("var")
                            .Where(p => p.Attribute("complexity")?.Value == generated_complexity[num - 1]
                            && p.Attribute("option")?.Value == generated_options[num - 1])
                            .Elements("task")
                            .Where(p => p.Attribute("num")?.Value == num.ToString())
                            .Elements("answer");
                if (task != null)
                    foreach (var item in task)
                        return answer == item.Value;
            }
            else
                rtb_Tasks.Text = "Ошибка проверки данных.";

            return false;
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (!answers_checked)
                label6.Text = "Сначала нужно проверить результат.";
            else
            {
                Save_Results();
                tb_Task1.Text = "";
                panel1.BackColor = Color.Black;
                tb_Task2.Text = "";
                panel2.BackColor = Color.Black;
                tb_Task3.Text = "";
                panel3.BackColor = Color.Black;
                tb_Task4.Text = "";
                panel4.BackColor = Color.Black;
                tb_Task5.Text = "";
                panel5.BackColor = Color.Black;
                answers_checked = false;
                Generate_Var();
            }
        }

        private void Save_Results()
        {
            conn.Open();

            for (int i = 0; i < 5; i++)
            {
                if (generated_complexity[i] == "1")
                    results1[i] = results[i];
                else if (generated_complexity[i] == "2")
                    results2[i] = results[i];
                else
                    results3[i] = results[i];
            }

            if (generated_complexity.Contains("1"))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO complexity_1 (student, task1, task2, task3, task4, task5, trying) " +
                                                      "VALUES (@student, @task1, @task2, @task3, @task4, @task5, @trying)", conn);
                cmd.Parameters.AddWithValue("@student", id);
                cmd.Parameters.AddWithValue("@task1", results1[0]);
                cmd.Parameters.AddWithValue("@task2", results1[1]);
                cmd.Parameters.AddWithValue("@task3", results1[2]);
                cmd.Parameters.AddWithValue("@task4", results1[3]);
                cmd.Parameters.AddWithValue("@task5", results1[4]);
                cmd.Parameters.AddWithValue("@trying", trying + 1);
                cmd.ExecuteNonQuery();
            }
            if (generated_complexity.Contains("2"))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO complexity_2 (student, task1, task2, task3, task4, task5, trying) " +
                                                      "VALUES (@student, @task1, @task2, @task3, @task4, @task5, @trying)", conn);
                cmd.Parameters.AddWithValue("@student", id);
                cmd.Parameters.AddWithValue("@task1", results2[0]);
                cmd.Parameters.AddWithValue("@task2", results2[1]);
                cmd.Parameters.AddWithValue("@task3", results2[2]);
                cmd.Parameters.AddWithValue("@task4", results2[3]);
                cmd.Parameters.AddWithValue("@task5", results2[4]);
                cmd.Parameters.AddWithValue("@trying", trying + 1);
                cmd.ExecuteNonQuery();
            }
            if (generated_complexity.Contains("3"))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO complexity_3 (student, task1, task2, task3, task4, task5, trying) " +
                                                      "VALUES (@student, @task1, @task2, @task3, @task4, @task5, @trying)", conn);
                cmd.Parameters.AddWithValue("@student", id);
                cmd.Parameters.AddWithValue("@task1", results3[0]);
                cmd.Parameters.AddWithValue("@task2", results3[1]);
                cmd.Parameters.AddWithValue("@task3", results3[2]);
                cmd.Parameters.AddWithValue("@task4", results3[3]);
                cmd.Parameters.AddWithValue("@task5", results3[4]);
                cmd.Parameters.AddWithValue("@trying", trying + 1);
                cmd.ExecuteNonQuery();
            }

            trying++;
            results = new bool[] { false, false, false, false, false };
            conn.Close();
        }

        private void tb_Task1_TextChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            answers_checked = false;
        }

        private void tb_Task2_TextChanged(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Black;
            answers_checked = false;
        }

        private void tb_Task3_TextChanged(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Black;
            answers_checked = false;
        }

        private void tb_Task4_TextChanged(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
            answers_checked = false;
        }

        private void tb_Task5_TextChanged(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Black;
            answers_checked = false;
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            if (!rtb_Status.Visible)
                Size = new Size(965, Size.Height);
            else
                Size = new Size(612, Size.Height);
            rtb_Status.Visible = !rtb_Status.Visible;
        }

        private void Show_Status()
        {
            rtb_Status.Text = $"ID: {id}";
            rtb_Status.Text += $"\nTrying: {trying + 1}";

            rtb_Status.Text += "\nGenerated var: ";
            for (int i = 0; i < 5; i++)
                rtb_Status.Text += $"({generated_complexity[i]}-{generated_options[i]}) ";

            rtb_Status.Text += "\nResults: ";
            foreach (bool item in results)
                rtb_Status.Text += $"{item} ";

            rtb_Status.Text += "\nLast results 1: ";
            foreach (bool item in results1)
                rtb_Status.Text += $"{item} ";

            rtb_Status.Text += "\nLast results 2: ";
            foreach (bool item in results2)
                rtb_Status.Text += $"{item} ";

            rtb_Status.Text += "\nLast results 3: ";
            foreach (bool item in results3)
                rtb_Status.Text += $"{item} ";
        }

        private void btn_Again_Click(object sender, EventArgs e)
        {
            Form_Again form2 = new Form_Again();
            form2.ShowDialog();
            if (form2.yes)
            {
                Delete_Student();
                tb_Task1.Text = "";
                tb_Task2.Text = "";
                tb_Task3.Text = "";
                tb_Task4.Text = "";
                tb_Task5.Text = "";
                results = new bool[] { false, false, false, false, false };
                results1 = new bool[] { false, false, false, false, false };
                results2 = new bool[] { false, false, false, false, false };
                results3 = new bool[] { false, false, false, false, false };
                trying = 0;
                answers_checked = false;
                Generate_Var();
            }
        }

        internal void Delete_Student()
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM complexity_1 WHERE student = @student", conn);
            cmd.Parameters.AddWithValue("@student", id);
            cmd.ExecuteNonQuery();
            cmd = new NpgsqlCommand("DELETE FROM complexity_2 WHERE student = @student", conn);
            cmd.Parameters.AddWithValue("@student", id);
            cmd.ExecuteNonQuery();
            cmd = new NpgsqlCommand("DELETE FROM complexity_3 WHERE student = @student", conn);
            cmd.Parameters.AddWithValue("@student", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Recreate_Data_Base()
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM complexity_1", conn);
            cmd.ExecuteNonQuery();
            cmd = new NpgsqlCommand("DELETE FROM complexity_2", conn);
            cmd.ExecuteNonQuery();
            cmd = new NpgsqlCommand("DELETE FROM complexity_3", conn);
            cmd.ExecuteNonQuery();

            Random r = new Random();

            XDocument xdoc = XDocument.Load("db.xml");
            XElement? ids = xdoc.Element("ids");
            ids?.Elements().Remove();

            for (int i = 0; i < 100; i++)
            {
                int randID = r.Next(100000000, 1000000000);
                cmd = new NpgsqlCommand("INSERT INTO complexity_1 (student, task1, task2, task3, task4, task5, trying)" +
                                        "VALUES (@student, @task1, @task2, @task3, @task4, @task5, @trying)", conn);
                cmd.Parameters.AddWithValue("@student", randID);
                cmd.Parameters.AddWithValue("@task1", Convert.ToBoolean(r.Next(0, 2)));
                cmd.Parameters.AddWithValue("@task2", Convert.ToBoolean(r.Next(0, 2)));
                cmd.Parameters.AddWithValue("@task3", Convert.ToBoolean(r.Next(0, 2)));
                cmd.Parameters.AddWithValue("@task4", Convert.ToBoolean(r.Next(0, 2)));
                cmd.Parameters.AddWithValue("@task5", Convert.ToBoolean(r.Next(0, 2)));
                cmd.Parameters.AddWithValue("@trying", 1);
                cmd.ExecuteNonQuery();
                ids?.Add(new XElement("id", randID.ToString()));
            }

            xdoc.Save("db.xml");

            if (ids != null)
            {
                foreach (var item in ids.Elements())
                {
                    cmd = new NpgsqlCommand("INSERT INTO complexity_2 (student, task1, task2, task3, task4, task5, trying)" +
                                            "VALUES (@student, @task1, @task2, @task3, @task4, @task5, @trying)", conn);
                    cmd.Parameters.AddWithValue("@student", Convert.ToInt32(item.Value));
                    cmd.Parameters.AddWithValue("@task1", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task2", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task3", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task4", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task5", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@trying", 2);
                    cmd.ExecuteNonQuery();

                    cmd = new NpgsqlCommand("INSERT INTO complexity_3 (student, task1, task2, task3, task4, task5, trying)" +
                                            "VALUES (@student, @task1, @task2, @task3, @task4, @task5, @trying)", conn);
                    cmd.Parameters.AddWithValue("@student", Convert.ToInt32(item.Value));
                    cmd.Parameters.AddWithValue("@task1", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task2", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task3", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task4", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@task5", Convert.ToBoolean(r.Next(0, 2)));
                    cmd.Parameters.AddWithValue("@trying", 3);
                }
            }

            conn.Close();
        }
    }
}