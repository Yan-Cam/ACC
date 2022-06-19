using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using aac.entity;

namespace aac.service
{
    public class UpdateService
    {
              public void update(String json) {
                    String sql = "truncate table contactinfo";
                    int r = SQLHelper.ExecuteNonQuery(sql);
                    JObject Okjson  = JObject.Parse(json);
                    JArray array = (JArray)Okjson["rows"];
              foreach(JObject item in array) {
                    int uid = Convert.ToInt32(item.GetValue("uid"));
                    String name = item.GetValue("name").ToString();
                    String phone = item.GetValue("phone").ToString();
                    String wechat = item.GetValue("wechat").ToString();
                    String qq = item.GetValue("qq").ToString();
                    String address = item.GetValue("address").ToString();
                    String sql2 = "insert into contactinfo values("+uid+", \""+name+"\", \""+phone+"\", \""+wechat+"\", \""+qq+"\", \""+address+"\")";
                    SQLHelper.ExecuteNonQuery(sql2);
              }
          } 
    }
}