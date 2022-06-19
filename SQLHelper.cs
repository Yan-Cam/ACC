using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;
namespace aac
{
   /// <summary>
   /// 通用数据访问类
   /// </summary>
   public class SQLHelper
   {
       //定义连接字符串
       private static string connString = "server=111.229.179.231;port=3306;database=asp;user=root;Password=19495201314qq`;CharSet=utf8;";
       
       //执行增删改
       public static int ExecuteNonQuery(string sql, params MySqlParameter[] pms)
       {
           using ( MySqlConnection con = new MySqlConnection(connString))
           {
               using (MySqlCommand cmd = new MySqlCommand(sql, con))
               {

                   if (pms != null)
                   {
                       cmd.Parameters.AddRange(pms);

                   }
                   con.Open();
                   return cmd.ExecuteNonQuery();
               }
           }
       }
       //执行返回SqlDataReader
       public static MySqlDataReader ExecuteReader(string sql,  params MySqlParameter[] pms)
       {
           MySqlConnection con = new MySqlConnection(connString);

           using (MySqlCommand cmd = new MySqlCommand(sql, con))
           {
               if (pms != null)
               {
                   cmd.Parameters.AddRange(pms);
               }
               try
               {
                   con.Open();
                   return cmd.ExecuteReader();
               }
               catch (Exception)
               {
                   con.Close();
                   con.Dispose();
                   throw;
               }
               finally {
                   con.Close();
               }

           }

       }
       //执行返回单个值：第一列第一行
       public static object ExecuteScalar(string sql, params MySqlParameter[] pms)
       {
           using (MySqlConnection con = new MySqlConnection(connString))
           {
               using (MySqlCommand cmd = new MySqlCommand(sql, con))
               {
                   if (pms != null)
                   {
                       cmd.Parameters.AddRange(pms);
                   }
                   con.Open();
                   return cmd.ExecuteScalar();
               }
           }
       }
       //执行返回datatable
       public static DataTable ExecuteDataTable(string sql, params MySqlParameter[] pms)
       {
           DataTable dt = new DataTable();
           using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connString))
           {
               if (pms != null)
               {
                   adapter.SelectCommand.Parameters.AddRange(pms);

               }
               adapter.Fill(dt);
               return dt;
           }

       }
   }
}