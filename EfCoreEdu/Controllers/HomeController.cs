using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft;
using EfCoreEdu.Models;
namespace EfCoreEdu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        SqlConnection connection = new SqlConnection("Server=DESKTOP-HEK9VG2;Database=efcore;Integrated Security=True;TrustServerCertificate=True");
        
        //Kayıtları Getirme İşlemi SQL
        [HttpGet("[action]")]
        public IActionResult GetList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From SimpleTables", connection);
            DataTable dataTable = new DataTable();
            
            dataTable.Clear();
            adapter.Fill(dataTable);

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
            return Ok(result);
        }
       
        

        //Yeni Kayıt Ekleme İşlemi SQL
        [HttpPost("[action]")]
        public IActionResult Add(SimpleTable simpleTable)
        {
            SqlCommand command = new SqlCommand("insert into SimpleTables(Name) values('" + simpleTable.Name + "')" , connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return Ok("Kayıt İşlemi Başarılı!");
        }
       
        
        
        //Kayıtları Güncelleme İşlemi
        [HttpPost("[action]")]
        public IActionResult Update(SimpleTable simpleTable)
        {
            SqlCommand command = new SqlCommand("update SimpleTables set Name=@parametreName where Id=@parametreId" , connection);
            command.Parameters.AddWithValue("@parametreName", simpleTable.Name);
            command.Parameters.AddWithValue("@parametreId", simpleTable.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return Ok("Güncelleme İşlemi Başarılı!");

        }



        //Kayıtları Silme İşlemi
        [HttpDelete("[action]")]
        public IActionResult Delete(SimpleTable simpleTable)
        {
            SqlCommand command = new SqlCommand("delete from SimpleTables where Id=@parametreId", connection);
            command.Parameters.AddWithValue("@parametreId", simpleTable.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return Ok("Silme İşlemi Başarılı!");
        }


         
    }


}
