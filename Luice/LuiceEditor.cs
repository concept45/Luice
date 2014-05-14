﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace Luice
{
    public partial class LuiceEditor : Form
    {
        
        public LuiceEditor()
        {
            InitializeComponent();
                        
        }
        private readonly Form1 connform;
        public LuiceEditor(Form1 form1)
        {
            InitializeComponent();
            connform = form1;
        }
        private void findCreatureBtn_Click(object sender, EventArgs e)
        {
            if (!connform.GetSsh())
            {

                MySqlConnection conn1 = new MySqlConnection("Server=" + connform.GetHost() + ";Database=" + connform.GetWorld() + ";UID=" + connform.GetUser() + ";Password=" + connform.GetPsw() + ";");
                conn1.Open();

                MySqlCommand cmd = new MySqlCommand("select entry, name, subname, npcflag, minlevel, maxlevel, count, name_loc, subname_loc from creature_template where entry = " + npcEntryTxt.Text + "; ", conn1);
                MySqlDataReader read = cmd.ExecuteReader();
                int pos = -1;
                while (read.Read())
                {
                    pos = creatureSearchDgv.Rows.Add();
                    creatureSearchDgv.Rows[pos].Cells["entry"].Value = Convert.ToString(read["entry"]);
                    creatureSearchDgv.Rows[pos].Cells["name"].Value = Convert.ToString(read["name"]);
                    creatureSearchDgv.Rows[pos].Cells["subname"].Value = Convert.ToString(read["subname"]);
                    creatureSearchDgv.Rows[pos].Cells["npcflag"].Value = Convert.ToString(read["npcflag"]);
                    creatureSearchDgv.Rows[pos].Cells["minlevel"].Value = Convert.ToString(read["minlevel"]);
                    creatureSearchDgv.Rows[pos].Cells["maxlevel"].Value = Convert.ToString(read["maxlevel"]);
                    creatureSearchDgv.Rows[pos].Cells["count"].Value = Convert.ToString(read["count"]);
                    creatureSearchDgv.Rows[pos].Cells["name_loc*"].Value = Convert.ToString(read["name_loc"]);
                    creatureSearchDgv.Rows[pos].Cells["subname_loc*"].Value = Convert.ToString(read["subname_loc"]);
                }
                conn1.Close();
            }
            else
            {
                MessageBox.Show("mysql ssh connection not yet supported");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
