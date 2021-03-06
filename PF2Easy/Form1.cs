﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PF2Easy
{
    public partial class Form1 : Form
    {
        static string cmd;
        int budget = 0;
        int spent = 0;
        int difficulty = 0;
        int threat = 0;
        int avglevel = 0;
        string limiter = "";
        int sortCol = 2;
        int party = 4;
        int difficultyIndex = 0;

        int initialheight = 0;

        ListSortDirection ascending = ListSortDirection.Descending;
        //int selectedXPVal = 0;

        List<Creature> encounter;
        List<Dupes> dupes;

        public Form1()
        {
            try
            {
                InitializeComponent();
                PopulateDataGrid(false);
                InitializeStuff();
            }
            catch (Exception estart)
            {
                MessageBox.Show(estart.Message);
            }
        }

        private void InitializeScaling()
        {
            initialheight = panelFlow.Location.Y;
        }

        private void InitializeStuff()
        {
            try
            {
                dataGridViewCreatures.BackgroundColor = Color.FromArgb(255, 64, 64, 64);
                dataGridViewCreatures.ForeColor = Color.Black;
                dataGridViewCreatures.EnableHeadersVisualStyles = false;
                dataGridViewCreatures.Font = new Font("Tahoma", 8.25f);
                budget = 0;
                spent = 0;
                avglevel = (int)numericUpDown2.Value;
                webBrowser1.ScriptErrorsSuppressed = true;
                comboBoxSLevel.SelectedIndex = 0;
                comboBox1.SelectedIndex = 2;
                difficultyIndex = comboBox1.SelectedIndex;
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
                CheckSearchParameters();
                dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);
                toolStripStatusLabel1.Text = "Loaded Encounter: New";
            }
            catch (Exception estart)
            {
                MessageBox.Show(estart.Message);
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
                int i = 0;
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
                    dataGridViewCreatures.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                    dataGridViewCreatures.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                    //dataGridViewCreatures.Rows[i].style = Color.DarkGray;
                    i++;
                }
            }
            sqlite_conn.Close();

            dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);
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

            budget = (newBudget - spent);
            textBoxValue.Text = spent.ToString();
            if (threat != -1)
            {
                textBoxBudget.Text = budget.ToString();
                textBoxValue.Text = spent.ToString();

            }
            else
            {
                textBoxBudget.Text = "infinite";
                textBoxValue.Text = spent.ToString();

            }

        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //difficulty/threat
        {
            difficultyIndex = comboBox1.SelectedIndex;
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
            CheckSearchParameters();
            dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);

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
            party = (int)numericUpDown3.Value;
            difficulty = party - 4;

            UpdateBudget();
            CheckSearchParameters();
            dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);

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
                    toolStripStatusLabel1.Text = "Loaded Encounter: New";
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                avglevel = (int)numericUpDown2.Value;
                budget = 0;
                UpdateBudget();
                CheckSearchParameters();
                dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);

            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckSearchParameters()
        {
            //Calculate the possible monster choices based on xp value remaining.
            dataGridViewCreatures.Rows.Clear();
            SqliteConnection sqlite_conn;

            sqlite_conn = new SqliteConnection(@"Data Source=.\DB\Monsters.db;");

            sqlite_conn.Open();
            SqliteCommand comm = new SqliteCommand("Select * From MASTER_MONSTERS", sqlite_conn);
            using (SqliteDataReader read = comm.ExecuteReader())
            {
                int i = 0;
                while (read.Read())
                {
                    Creature temp = new Creature();
                    temp.NAME = read.GetValue(read.GetOrdinal("Name")).ToString();  // Or column name like this
                    temp.FAMILY = read.GetValue(read.GetOrdinal("Family")).ToString();
                    temp.LEVEL = Int32.Parse(read.GetValue(read.GetOrdinal("Level")).ToString());
                    temp.ALIGNMENT = read.GetValue(read.GetOrdinal("Alignment")).ToString();
                    temp.TYPE = read.GetValue(read.GetOrdinal("Type")).ToString();
                    temp.SIZE = read.GetValue(read.GetOrdinal("Size")).ToString();
                    temp.URL = read.GetValue(read.GetOrdinal("URL")).ToString();


                    if (CalculateDifficulty(temp, true))
                    {
                        dataGridViewCreatures.Rows.Add(new object[] {
            //read.GetValue(0),  // U can use column index
            temp.NAME,temp.FAMILY,temp.LEVEL,temp.ALIGNMENT,temp.TYPE,temp.SIZE,temp.URL
            });
                        dataGridViewCreatures.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dataGridViewCreatures.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                        i++;
                    }
                }
            }
            sqlite_conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)//Search
        {
            SearchCreatures();
        }

        private void SearchCreatures()
        {
            dataGridViewCreatures.Rows.Clear();
            SqliteConnection sqlite_conn;
            string OptionalQuery = "";
            int count = 0;
            if (textBoxSFamily.Text != "")
            {
                count++;
                if (count == 0)
                    OptionalQuery += " Family LIKE '%" + textBoxSFamily.Text + "%'";
                else
                    OptionalQuery += " AND Family LIKE '%" + textBoxSFamily.Text + "%'";

            }
            if (textBoxSCreat.Text != "")
            {
                count++;
                if (count == 0)
                    OptionalQuery += " AND Name LIKE '%" + textBoxSCreat.Text + "%'";
                else
                    OptionalQuery += " Name LIKE '%" + textBoxSCreat.Text + "%'";
            }
            if (textBoxSAlign.Text != "")
            {
                count++;
                if (count == 0)
                    OptionalQuery += " AND Alignment LIKE '%" + textBoxSAlign.Text + "%'";
                else
                    OptionalQuery += " Alignment LIKE '%" + textBoxSAlign.Text + "%'";

            }
            if (textBoxSSize.Text != "")
            {
                count++;
                if (count == 0)
                    OptionalQuery += " AND Size LIKE '%" + textBoxSSize.Text + "%'";
                else
                    OptionalQuery += " Size LIKE '%" + textBoxSSize.Text + "%'";
            }
            if (textBoxSType.Text != "")
            {
                count++;
                if (count == 0)
                    OptionalQuery += " AND Type LIKE '%" + textBoxSType.Text + "%'";
                else
                    OptionalQuery += " Type LIKE '%" + textBoxSType.Text + "%'";
            }
            if (comboBoxSLevel.Text != " ")
            {
                count++;
                if (count == 0)
                    OptionalQuery += " AND Level " + comboBoxSLevel.Text + " " + numericUpDownSLevel.Value;
                else
                    OptionalQuery += " Level " + comboBoxSLevel.Text + " " + numericUpDownSLevel.Value;
            }

            sqlite_conn = new SqliteConnection(@"Data Source=.\DB\Monsters.db;");
            //add WHERE LEVEL [operation] 
            sqlite_conn.Open();
            SqliteCommand comm = new SqliteCommand("Select * From MASTER_MONSTERS WHERE" + OptionalQuery + limiter + ";", sqlite_conn);
            using (SqliteDataReader read = comm.ExecuteReader())
            {
                int i = 0;
                while (read.Read())
                {
                    Creature temp = new Creature();
                    temp.NAME = read.GetValue(read.GetOrdinal("Name")).ToString();  // Or column name like this
                    temp.FAMILY = read.GetValue(read.GetOrdinal("Family")).ToString();
                    temp.LEVEL = Int32.Parse(read.GetValue(read.GetOrdinal("Level")).ToString());
                    temp.ALIGNMENT = read.GetValue(read.GetOrdinal("Alignment")).ToString();
                    temp.TYPE = read.GetValue(read.GetOrdinal("Type")).ToString();
                    temp.SIZE = read.GetValue(read.GetOrdinal("Size")).ToString();
                    temp.URL = read.GetValue(read.GetOrdinal("URL")).ToString();
                    if (checkBoxAffordable.Checked)
                    {
                        if (CalculateDifficulty(temp, true))
                        {
                            dataGridViewCreatures.Rows.Add(new object[] {
            temp.NAME,temp.FAMILY,temp.LEVEL,temp.ALIGNMENT,temp.TYPE,temp.SIZE,temp.URL
            });
                            dataGridViewCreatures.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                            dataGridViewCreatures.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                            i++;
                        }
                    }
                    else
                    {
                        dataGridViewCreatures.Rows.Add(new object[] {
            temp.NAME,temp.FAMILY,temp.LEVEL,temp.ALIGNMENT,temp.TYPE,temp.SIZE,temp.URL
            });
                        dataGridViewCreatures.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dataGridViewCreatures.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                        i++;
                    }
                }
            }
            sqlite_conn.Close();
            dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);
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

        private bool CalculateDifficulty(Creature c, bool Check)
        {
            if (threat == -1) //allow any if custom
            {
                //return true;
                budget += 50000;
            }
            int scalar = c.LEVEL - avglevel;
            if (scalar > 4)
            {
                return false;
            }

            if (scalar <= -4)
            {
                if (budget >= 10)
                {
                    if (!Check)
                    {
                        budget -= 10;
                        spent += 10;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == -3)
            {
                if (budget >= 15)
                {
                    if (!Check)
                    {
                        budget -= 15;
                        spent += 15;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == -2)
            {
                if (budget >= 20)
                {
                    if (!Check)
                    {
                        budget -= 20;
                        spent += 20;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == -1)
            {
                if (budget >= 30)
                {
                    if (!Check)
                    {
                        budget -= 30;
                        spent += 30;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == 0)
            {
                if (budget >= 40)
                {
                    if (!Check)
                    {
                        budget -= 40;
                        spent += 40;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == 1)
            {
                if (budget >= 60)
                {
                    if (!Check)
                    {
                        budget -= 60;
                        spent += 60;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == 2)
            {
                if (budget >= 80)
                {
                    if (!Check)
                    {
                        budget -= 80;
                        spent += 80;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == 3)
            {
                if (budget >= 120)
                {
                    if (!Check)
                    {
                        budget -= 120;
                        spent += 120;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar == 4)
            {
                if (budget >= 160)
                {
                    if (!Check)
                    {
                        budget -= 160;
                        spent += 160;
                    }
                    if (threat == -1)
                        budget -= 50000;
                    return true;
                }
            }
            else if (scalar > 4 && threat == -1)
            {
                float tempScalar = scalar;
                if (budget >= 160 + 60 * ((int)tempScalar / 2))
                {

                    budget -= 160 + 60 * ((int)tempScalar / 2);
                    spent += 160 + 60 * ((int)tempScalar / 2);
                }
                if (threat == -1)
                    budget -= 50000;
                return true;
            }
            return false;
        }

        private void Refund(Creature c)
        {
            int scalar = c.LEVEL - avglevel;

            if (scalar <= -4)
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
            else if (scalar > 4)
            {
                float tempScalar = scalar;
                budget += 160 + 60 * ((int)tempScalar / 2);
                spent -= 160 + 60 * ((int)tempScalar / 2);

            }
            textBoxBudget.Text = budget.ToString();
            textBoxValue.Text = spent.ToString();

            if (threat == -1)
            {
                textBoxBudget.Text = "infinite";
                textBoxValue.Text = spent.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)//Add to Encounter
        {
            AddCreature();
        }

        private void AddCreature()
        {
            try
            {

                Creature creature = new Creature();
                creature.NAME = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                creature.FAMILY = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                creature.LEVEL = Int32.Parse(dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[2].Value.ToString());
                creature.ALIGNMENT = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
                creature.TYPE = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
                creature.SIZE = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
                creature.URL = dataGridViewCreatures.Rows[dataGridViewCreatures.SelectedCells[0].RowIndex].Cells[6].Value.ToString();
                if (CalculateDifficulty(creature, false))
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
                    }

                    //write encounter to listBox_Encounter
                    foreach (Dupes dupe in dupes)
                    {
                        listBox_Encounter.Items.Add(dupe.NAME + " x" + dupe.COUNT);
                    }
                    if (threat != -1)
                    {
                        textBoxBudget.Text = budget.ToString();
                        textBoxValue.Text = spent.ToString();

                    }
                    else
                    {
                        textBoxBudget.Text = "infinite";
                        textBoxValue.Text = spent.ToString();

                    }
                    CheckSearchParameters();
                    dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);


                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveCreature();
        }

        private void RemoveCreature()
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
                CheckSearchParameters();
                dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);


            }
            catch (Exception e2)
            {


            }
        }

        private void dataGridViewCreatures_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sortCol = dataGridViewCreatures.SortedColumn.DisplayIndex;
            if (dataGridViewCreatures.SortOrder == SortOrder.Descending)
            {
                ascending = ListSortDirection.Descending;
            }
            else
            {
                ascending = ListSortDirection.Ascending;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PF2E Encounter|*.PFSE";
            saveFileDialog1.Title = "Save a PF2E Encounter File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                toolStripStatusLabel1.Text = "Loaded Encounter: " + Path.GetFileName(saveFileDialog1.FileName);
                using (BinaryWriter binWriter =
                    new BinaryWriter(saveFileDialog1.OpenFile()))
                {
                    // Write number of creatures in encounter
                    binWriter.Write(encounter.Count);
                    // Write number of creatures in dupes
                    binWriter.Write(dupes.Count);

                    //Write the amount of index files within each dupe
                    for (int i = 0; i < dupes.Count; i++)
                    {
                        binWriter.Write(dupes[i].INDEX.Count);
                    }
                    //Write Encounter creatures
                    for (int i = 0; i < encounter.Count; i++)
                    {
                        binWriter.Write(encounter[i].ALIGNMENT);
                        binWriter.Write(encounter[i].FAMILY);
                        binWriter.Write(encounter[i].LEVEL);
                        binWriter.Write(encounter[i].NAME);
                        binWriter.Write(encounter[i].SIZE);
                        binWriter.Write(encounter[i].TYPE);
                        binWriter.Write(encounter[i].URL);
                    }
                    //Write Dupes creatures
                    for (int i = 0; i < dupes.Count; i++)
                    {
                        binWriter.Write(dupes[i].COUNT);
                        for (int j = 0; j < dupes[i].INDEX.Count; j++)
                        {
                            binWriter.Write(dupes[i].INDEX[j]);
                        }
                        binWriter.Write(dupes[i].NAME);
                        binWriter.Write(dupes[i].URL);
                    }
                    binWriter.Write(budget);
                    binWriter.Write(spent);
                    binWriter.Write(difficultyIndex);
                    binWriter.Write(threat);
                    binWriter.Write(avglevel);
                    binWriter.Write(limiter);
                    binWriter.Write(party);

                    binWriter.Close();
                }
            }


            toolStripStatusLabel1.Text = "Loaded Encounter: " + saveFileDialog1.FileName;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog encFile = new OpenFileDialog();
            encFile.Title = "Open Text File";
            encFile.Filter = "PF2E Encounter|*.PFSE";
            encFile.InitialDirectory = @"C:\";
            if (encFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(encFile.FileName))
                    {
                        InitializeStuff();
                        toolStripStatusLabel1.Text = "Loaded Encounter: " + Path.GetFileName(encFile.FileName);

                        List<Creature> loadEnc = new List<Creature>();
                        List<Dupes> loadDupes = new List<Dupes>();
                        List<int> dupesIndexSizes = new List<int>();
                        using (BinaryReader reader = new BinaryReader(File.Open(encFile.FileName, FileMode.Open)))
                        {
                            int numEncounterCreatures = reader.ReadInt32();
                            int numDupesCreatures = reader.ReadInt32();
                            for (int i = 0; i < numDupesCreatures; i++)
                            {
                                dupesIndexSizes.Add(reader.ReadInt32());
                            }
                            for (int i = 0; i < numEncounterCreatures; i++)
                            {
                                Creature c = new Creature();
                                c.ALIGNMENT = reader.ReadString();
                                c.FAMILY = reader.ReadString();
                                c.LEVEL = reader.ReadInt32();
                                c.NAME = reader.ReadString();
                                c.SIZE = reader.ReadString();
                                c.TYPE = reader.ReadString();
                                c.URL = reader.ReadString();
                                loadEnc.Add(c);
                            }
                            for (int i = 0; i < numDupesCreatures; i++)
                            {
                                Dupes d = new Dupes();
                                d.COUNT = reader.ReadInt32();
                                d.INDEX = new List<int>();
                                for (int j = 0; j < dupesIndexSizes[i]; j++)
                                {
                                    d.INDEX.Add(reader.ReadInt32());
                                }
                                d.NAME = reader.ReadString();
                                d.URL = reader.ReadString();
                                loadDupes.Add(d);
                            }
                            budget = reader.ReadInt32();
                            spent = reader.ReadInt32();
                            difficultyIndex = reader.ReadInt32();
                            threat = reader.ReadInt32();
                            avglevel = reader.ReadInt32();
                            limiter = reader.ReadString();
                            party = reader.ReadInt32();
                            reader.Close();
                        }
                        textBoxBudget.Text = budget.ToString();
                        textBoxValue.Text = spent.ToString();

                        comboBox1.SelectedIndex = difficultyIndex;
                        numericUpDown2.Value = avglevel;
                        numericUpDown3.Value = party;

                        encounter = loadEnc;
                        dupes = loadDupes;
                        CheckSearchParameters();
                        foreach (Dupes dupe in dupes)
                        {
                            listBox_Encounter.Items.Add(dupe.NAME + " x" + dupe.COUNT);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load file :(");
                }
            }
        }

        private void dataGridViewCreatures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddCreature();
        }

        private void listBox_Encounter_DoubleClick(object sender, EventArgs e)
        {
            RemoveCreature();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (encounter.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Reset the encounter?\n Warning: This will clear all selected creatures!", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    avglevel = (int)numericUpDown2.Value;
                    InitializeStuff();
                    toolStripStatusLabel1.Text = "Loaded Encounter: New";
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else? meh
                }
            }
            else
            {
                avglevel = (int)numericUpDown2.Value;
                budget = 0;
                UpdateBudget();
                CheckSearchParameters();
                dataGridViewCreatures.Sort(dataGridViewCreatures.Columns[sortCol], ascending);

            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            dataGridViewCreatures.Width = splitContainer1.Panel1.Width - 15;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Point p = panelFlow.Location;
            p.Y = (splitContainer2.Panel1.Location.Y + splitContainer2.Panel1.Height) - panelFlow.Height;
            panelFlow.Location = p;

            dataGridViewCreatures.Height = p.Y - 75;
        }

        private void checkBoxAffordable_CheckedChanged(object sender, EventArgs e)
        {
            SearchCreatures();
        }
    }
    [Serializable]
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
    [Serializable]
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
