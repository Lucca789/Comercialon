﻿using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Comercialon.Classes
{
   public static class Banco
    {
        public static MySqlCommand Abrir()
        {
            MySqlCommand cmd = new MySqlCommand();
            string strConn = @"server=127.0.0.1;database=comercialondb;user id=root;password=usbw;port=3306";
            MySqlConnection cn = new MySqlConnection(strConn);
            try
            {
                if (cn.State!=ConnectionState.Open)
                {
                    cn.Open();
                    cmd.Connection = cn;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cmd;
        }
    }
}
