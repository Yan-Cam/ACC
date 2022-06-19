using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aac.entity;
using MySql.Data.MySqlClient;
using System.Data;
namespace aac.service
{
    public class CCSClass
    {
          public List<ContactClass> FindAllByPage() {
              List<ContactClass> ccs = new List<ContactClass>(); 
              String sql = "select * from contactinfo";
              MySqlParameter[] pms = null;
              DataTable dataTable = SQLHelper.ExecuteDataTable(sql, pms);
              foreach(DataRow row in dataTable.Rows) {
                    ContactClass contact = new ContactClass();
                    contact.uid = Convert.ToInt32(row["uid"]);
                    contact.phone = row["phone"].ToString();
                    contact.qq = row["qq"].ToString();
                    contact.wechat = row["wechat"].ToString();
                    contact.address = row["address"].ToString();
                    contact.name = row["name"].ToString();
                    ccs.Add(contact);
              }
              return ccs;
          } 
    }
}