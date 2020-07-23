using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace PF2Easy
{
    public partial class Form1 : Form
    {
        static string cmd;
        int budget = 0;
        int spent = 0;
        int difficulty = 0;
        int prevthreat = 0;
        int threat = 0;
        int avglevel = 0;
        //int selectedXPVal = 0;

        List<Creature> encounter;
        List<Dupes> dupes;

        public Form1()
        {
            InitializeComponent();
            PopulateDataGrid(false);
            InitializeStuff();
        }

        private void InitializeStuff()
        {
            budget = 0;
            spent = 0;
            avglevel = (int)numericUpDown2.Value;
            webBrowser1.ScriptErrorsSuppressed = true;
            comboBoxSLevel.SelectedIndex = 0;
            comboBox1.SelectedIndex = 2;
            numericUpDown3.Value = 4;
            encounter = new List<Creature>();
            dupes = new List<Dupes>();
            listBox_Encounter.Items.Clear();
            try
            {
                Uri u = new Uri(dataGridViewCreatures.Rows[0].Cells[6].Value.ToString());
                webBrowser1.Url = u;
            }
            catch (Exception er)
            {
                string msg = er.ToString();
            }
            UpdateBudget();
        }

        private void CreateConnection()
        {

            // Create a new database connection:
            //sqlite_conn = new SqliteConnection("Data Source= Monsters.db;");
            // Open the connection:
            try
            {
                //sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
        }

        //private void TemporaryImport()
        //{
        //    SqliteConnection sqlite_conn;
        //    sqlite_conn = new SqliteConnection(@"Data Source=.\DB\Monsters.db;");
        //    sqlite_conn.Open();
        //    SqliteCommand cmd;
        //    int index = 1;
        //    string[] monsters = System.IO.File.ReadAllLines(@"E:\Test\MonsterID.csv");
        //    foreach (string monster in monsters)
        //    {
        //        string id = monster.Split(',').Last();
        //        if (id != null && id != "")
        //        {
        //            cmd = new SqliteCommand("UPDATE MASTER_MONSTERS set URL ='https://2e.aonprd.com/Monsters.aspx?ID=" + id + "' WHERE id = " + index.ToString(), sqlite_conn);
        //            cmd.ExecuteNonQuery();
        //            index++;
        //        }
        //    }
        //}

        private void ReadData(SqliteConnection conn)
        {
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = cmd;

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }

        private void SetEncounterPadding()
        {

        }

        private void PopulateDataGrid(bool clear)
        {
            SqliteConnection sqlite_conn;

            if (!clear)
            {
                dataGridViewCreatures.Columns.Add("Name", "Name");
                dataGridViewCreatures.Columns.Add("Family", "Family");
                dataGridViewCreatures.Columns.Add("Level", "Level");
                dataGridViewCreatures.Columns.Add("Alignment", "Alignment");
                dataGridViewCreatures.Columns.Add("Type", "Type");
                dataGridViewCreatures.Columns.Add("Size", "Size");
                dataGridViewCreatures.Columns.Add("URL", "URL");
                dataGridViewCreatures.Columns["URL"].Visible = false;
            }
            //sqlite_conn = new SqliteConnection("Data Source= Monsters.db;");
            //dataGridViewCreatures.DataSource =
            sqlite_conn = new SqliteConnection(@"Data Source=.\DB\Monsters.db;");

            sqlite_conn.Open();
            SqliteCommand comm = new SqliteCommand("Select * From MASTER_MONSTERS", sqlite_conn);
            using (SqliteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridViewCreatures.Rows.Add(new object[] {
            //read.GetValue(0),  // U can use column index
            read.GetValue(read.GetOrdinal("Name")),  // Or column name like this
            read.GetValue(read.GetOrdinal("Family")),
            read.GetValue(read.GetOrdinal("Level")),
            read.GetValue(read.GetOrdinal("Alignment")),
            read.GetValue(read.GetOrdinal("Type")),
            read.GetValue(read.GetOrdinal("Size")),
                    read.GetValue(read.GetOrdinal("URL"))
            });
                }
            }
            sqlite_conn.Close();
        }

        private void UpdateBudget()
        {
            int newBudget = 0;
            switch (threat)
            {
                case 40:
                    newBudget = threat + (10 * difficulty);
                    break;
                case 60:
                    newBudget = threat + (15 * difficulty);
                    break;
                case 80:
                    newBudget = threat + (20 * difficulty);
                    break;
                case 120:
                    newBudget = threat + (30 * difficulty);
                    break;
                case 160:
                    newBudget = threat + (40 * difficulty);
                    break;
            }
            //if (prevthreat > threat)
            //{
            //    //budget -= newBudget;
            //}
            //else if (prevthreat < threat)
            //{
            //    //budget += newBudget;
            //}
            budget = (newBudget - spent);

            if (threat != -1)
                textBoxBudget.Text = budget.ToString();
            else
                textBoxBudget.Text = "infinite";

        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //difficulty/threat
        {
            prevthreat = threat;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Trivial":
                    threat = 40;
                    break;
                case "Low":
                    threat = 60;
                    break;
                case "Moderate":
                    threat = 80;
                    break;
                case "Severe":
                    threat = 120;
                    break;
                case "Extreme":
                    threat = 160;
                    break;
                case "Custom":
                    threat = -1;
                    break;
                default:
                    threat = 0;
                    break;

            }
            UpdateBudget();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewCreatures_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Uri u = new Uri(dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[6].Value.ToString());
                webBrowser1.Url = u;
            }
            catch (Exception er)
            {
                string msg = er.ToString();
            }
        }

        private void listBox_Encounter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                Uri u = new Uri(dupes[listBox_Encounter.SelectedIndex].URL);
                webBrowser1.Url = u;
            }
            catch (Exception er)
            {
                string msg = er.ToString();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            int party = 4;
            party = (int)numericUpDown3.Value;
            difficulty = party - 4;

            UpdateBudget();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (encounter.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Changing party level will reset the encounter!\nAre you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    avglevel = (int)numericUpDown2.Value;
                    InitializeStuff();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                avglevel = (int)numericUpDown2.Value;
                UpdateBudget();
            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckSearchParameters()
        {
            //Calculate the possible monster choices based on xp value remaining.
        }

        private void button2_Click(object sender, EventArgs e)//Search
        {
            dataGridViewCreatures.Rows.Clear();
            SqliteConnection sqlite_conn;
            string OptionalQuery = "";

            if (textBoxSFamily.Text != "")
            {
                OptionalQuery += " AND Family LIKE '%" + textBoxSFamily.Text + "%'";
            }
            if (textBoxSCreat.Text != "")
            {
                OptionalQuery += " AND Name LIKE '%" + textBoxSCreat.Text + "%'";
            }
            if (textBoxSAlign.Text != "")
            {
                OptionalQuery += " AND Alignment LIKE '%" + textBoxSAlign.Text + "%'";
            }
            if (textBoxSSize.Text != "")
            {
                OptionalQuery += " AND Size LIKE '%" + textBoxSSize.Text + "%'";
            }
            if (textBoxSType.Text != "")
            {
                OptionalQuery += " AND Type LIKE '%" + textBoxSType.Text + "%'";
            }


            sqlite_conn = new SqliteConnection(@"Data Source=.\DB\Monsters.db;");

            sqlite_conn.Open();
            SqliteCommand comm = new SqliteCommand("Select * From MASTER_MONSTERS where Level " + comboBoxSLevel.Text + " " + numericUpDownSLevel.Value + OptionalQuery + ";", sqlite_conn);
            using (SqliteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridViewCreatures.Rows.Add(new object[] {
            //read.GetValue(0),  // U can use column index
            read.GetValue(read.GetOrdinal("Name")),  // Or column name like this
            read.GetValue(read.GetOrdinal("Family")),
            read.GetValue(read.GetOrdinal("Level")),
            read.GetValue(read.GetOrdinal("Alignment")),
            read.GetValue(read.GetOrdinal("Type")),
            read.GetValue(read.GetOrdinal("Size")),
                    read.GetValue(read.GetOrdinal("URL"))
            });
                }
            }
            sqlite_conn.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridViewCreatures.Rows.Clear();
            textBoxSAlign.Text = "";
            textBoxSCreat.Text = "";
            textBoxSFamily.Text = "";
            textBoxSSize.Text = "";
            textBoxSType.Text = "";

            PopulateDataGrid(true);
        }

        private bool CalculateDifficulty(Creature c)
        {
            if (threat == -1) //allow any if custom
            {
                return true;
            }
            int scalar = c.LEVEL - avglevel;
            if (scalar < -4)
            {
                return false;
            }
            else if (scalar > 4)
            {
                return false;
            }

            if (scalar == -4)
            {
                if (budget >= 10)
                {
                    budget -= 10;
                    spent += 10;
                    return true;
                }
            }
            else if (scalar == -3)
            {
                if (budget >= 15)
                {
                    budget -= 15;
                    spent += 15;
                    return true;
                }
            }
            else if (scalar == -2)
            {
                if (budget >= 20)
                {
                    budget -= 20;
                    spent += 20;
                    return true;
                }
            }
            else if (scalar == -1)
            {
                if (budget >= 30)
                {
                    budget -= 30;
                    spent += 30;
                    return true;
                }
            }
            else if (scalar == 0)
            {
                if (budget >= 40)
                {
                    budget -= 40;
                    spent += 40;
                    return true;
                }
            }
            else if (scalar == 1)
            {
                if (budget >= 60)
                {
                    budget -= 60;
                    spent += 60;
                    return true;
                }
            }
            else if (scalar == 2)
            {
                if (budget >= 80)
                {
                    budget -= 80;
                    spent += 80;
                    return true;
                }
            }
            else if (scalar == 3)
            {
                if (budget >= 120)
                {
                    budget -= 120;
                    spent += 120;
                    return true;
                }
            }
            else if (scalar == 4)
            {
                if (budget >= 160)
                {
                    budget -= 160;
                    spent += 160;
                    return true;
                }
            }
            return false;
        }

        private void Refund(Creature c)
        {
            if (threat != -1) //allow any if custom
            {
                int scalar = avglevel - c.LEVEL;

                if (scalar == -4)
                {
                    budget += 10;
                    spent -= 10;
                }
                else if (scalar == -3)
                {
                    budget += 15;
                    spent -= 15;
                }
                else if (scalar == -2)
                {
                    budget += 20;
                    spent -= 20;
                }
                else if (scalar == -1)
                {
                    budget += 30;
                    spent -= 30;
                }
                else if (scalar == 0)
                {
                    budget += 40;
                    spent -= 40;
                }
                else if (scalar == 1)
                {
                    budget += 60;
                    spent -= 60;
                }
                else if (scalar == 2)
                {
                    budget += 80;
                    spent -= 80;
                }
                else if (scalar == 3)
                {
                    budget += 120;
                    spent -= 120;
                }
                else if (scalar == 4)
                {
                    budget += 160;
                    spent -= 160;
                }
                textBoxBudget.Text = budget.ToString();
            }
            else
            {
                textBoxBudget.Text = "infinite";
            }
        }

        private void button1_Click(object sender, EventArgs e)//Add to Encounter
        {
            Creature creature = new Creature();
            creature.NAME = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            creature.FAMILY = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            creature.LEVEL = Int32.Parse(dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[2].Value.ToString());
            creature.ALIGNMENT = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            creature.TYPE = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
            creature.SIZE = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
            creature.URL = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[6].Value.ToString();
            if (CalculateDifficulty(creature))
            {
                encounter.Add(creature);


                listBox_Encounter.Items.Clear();

                dupes = new List<Dupes>();

                for (int i = 0; i < encounter.Count; i++)
                {

                    if (dupes.Count == 0)
                    {
                        Dupes dupe = new Dupes();
                        dupe.INDEX = new List<int>();
                        dupe.NAME = encounter[i].NAME;
                        dupe.COUNT = 0;
                        //dupe.INDEX.Add(i);
                        dupe.URL = encounter[i].URL;
                        dupes.Add(dupe);
                    }

                    bool d = false;
                    int index = 0;
                    for (int j = 0; j < dupes.Count; j++)
                    {

                        if (dupes[j].NAME == encounter[i].NAME)
                        {
                            d = true;
                            index = j;
                            break;
                        }
                    }

                    if (!d)
                    {
                        Dupes temp = new Dupes();
                        temp.INDEX = new List<int>();
                        temp.NAME = encounter[i].NAME;
                        temp.COUNT = 1;
                        temp.INDEX.Add(i);
                        temp.URL = encounter[i].URL;
                        dupes.Add(temp);
                    }
                    else
                    {
                        Dupes temp = new Dupes(dupes[index]);
                        temp.COUNT++;
                        temp.INDEX.Add(i);
                        dupes[index] = temp;
                    }


                    //if(!dupes.Contains(dupe))
                    //{
                    //    dupes.Add(dupe);
                    //}
                    //else
                    //{
                    //    Dupes temp = new Dupes(dupes[dupes.IndexOf(dupe)]);
                    //    temp.COUNT++;
                    //    dupes[dupes.IndexOf(dupe)] = temp;
                    //}
                }

                //write encounter to listBox_Encounter
                foreach (Dupes dupe in dupes)
                {
                    listBox_Encounter.Items.Add(dupe.NAME + " x" + dupe.COUNT);
                }
                if (threat != -1)
                    textBoxBudget.Text = budget.ToString();
                else
                    textBoxBudget.Text = "infinite";

            }
            else
            {

            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = listBox_Encounter.SelectedIndex;
            int index = 0;
            Creature remove;
            try
            {

                for (int i = 0; i < dupes.Count; i++)
                {
                    if (listBox_Encounter.SelectedItem.ToString().Contains(dupes[i].NAME))
                    {
                        index = listBox_Encounter.SelectedIndex;
                        break;
                    }
                }
                Dupes temp = new Dupes(dupes[index]);
                if (temp.COUNT > 1)
                {
                    temp.COUNT--;
                    dupes[index] = temp;
                    remove = encounter[dupes[index].INDEX[dupes[index].INDEX.Count - 1] - 1];
                    encounter.RemoveAt(dupes[index].INDEX[dupes[index].INDEX.Count - 1] - 1);
                    dupes[index].INDEX.RemoveAt(dupes[index].INDEX.Count - 1);
                    for (int i = 0; i < dupes.Count; i++)
                    {
                        for (int j = 0; j < dupes[i].INDEX.Count; j++)
                        {
                            if (dupes[index].INDEX.Count > 0)
                                if (dupes[i].INDEX[j] > dupes[index].INDEX[dupes[index].INDEX.Count - 1])
                                {
                                    Dupes copy = new Dupes(dupes[i]);
                                    //copy.INDEX[j]--;
                                    copy.INDEX[j]--;
                                    dupes[i] = copy;
                                }
                        }
                    }
                }
                else
                {
                    if (dupes.Count > 1)
                    {
                        remove = encounter[dupes[index].INDEX[dupes[index].INDEX.Count - 1]];
                        encounter.RemoveAt(dupes[index].INDEX[dupes[index].INDEX.Count - 1]);
                    }
                    else
                    {
                        remove = encounter[0];
                        encounter.RemoveAt(0);
                    }
                    //encounter.RemoveAt(dupes[index].INDEX[dupes[index].INDEX.Count - 1]-1);

                    dupes.RemoveAt(index);
                    if (index > 0)
                        index--;
                    for (int i = 0; i < dupes.Count; i++)
                    {
                        for (int j = 0; j < dupes[i].INDEX.Count; j++)
                        {
                            if (dupes[index].INDEX.Count > 0)
                                if (dupes[i].INDEX[j] > dupes[index].INDEX[dupes[index].INDEX.Count - 1])
                                {
                                    Dupes copy = new Dupes(dupes[i]);
                                    //copy.INDEX[j]--;
                                    copy.INDEX[j]--;
                                    dupes[i] = copy;
                                }
                        }
                    }
                }

                listBox_Encounter.Items.Clear();
                foreach (Dupes dupe in dupes)
                {
                    listBox_Encounter.Items.Add(dupe.NAME + " x" + dupe.COUNT);
                }
                if (listBox_Encounter.Items.Count > selectedItemIndex)
                    listBox_Encounter.SelectedIndex = selectedItemIndex;
                else
                {
                    listBox_Encounter.SelectedIndex = selectedItemIndex - 1;
                }

                //refund
                Refund(remove);

            }
            catch (Exception e2)
            {


            }
        }
    }

    public struct Dupes
    {
        public Dupes(Dupes d)
        {
            NAME = d.NAME;
            COUNT = d.COUNT;
            INDEX = d.INDEX;
            URL = d.URL;
        }
        public string NAME;
        public int COUNT;
        public List<int> INDEX;
        public string URL;
    }

    public struct Creature
    {
        public string NAME;
        public string FAMILY;
        public int LEVEL;
        public string ALIGNMENT;
        public string TYPE;
        public string SIZE;
        public string URL;
    }
}
