using EfCoreEdu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreEdu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfController : ControllerBase
    {
        DenemeContext context = new();

        //Ef Core ile Kayıtları Getirme
        [HttpGet("[action]")]
        public IActionResult GetList()
        {
            var result = context.SimpleTables.ToList();
            return Ok(result);
        }



        //Ef Core ile Id'ye Göre Kayıt Getirme 
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id )
        {
            var result = context.SimpleTables.ToList().Where(b => b.Id.Equals(id)).SingleOrDefault();
            //var result = context.SimpleTables.FirstOrDefault(p => p.Id.Equals(id)); şeklinde de yazılabilir.
            //SingleOrDefault kayıt var ise tek birini döndürür yoksa nulldır.
            //FirstOrDefault Eşleşen ilk öğeyi döndürür.Yoksa default değeri nulldur.
            return Ok(result);
        }


        //Ef Core ile Yeni Kayıt Ekleme
        [HttpPost("[action]")]
        public IActionResult Add(SimpleTable simpleTable)
        {
            context.SimpleTables.Add(simpleTable);
            context.SaveChanges();
            return Ok("Kayıt İşlemi Başarılı!");
        }
        
        
        
        //Ef Core ile Kayıt Güncelleme
        [HttpPost("[action]")]
        public IActionResult Update(SimpleTable simpleTable)
        {
            context.SimpleTables.Update(simpleTable);
            context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı!");
        }



        //Ef Core ile Kayıt Silme
        [HttpDelete("[action]")]
        public IActionResult Remove(SimpleTable simpleTable)
        {
            context.SimpleTables.Remove(simpleTable);
            context.SaveChanges();
            return Ok("Silme İşlemi Başarılı!");
        }



        //Ef Core ile Kayıt Silme Remove Range
        [HttpDelete("[action]")]
        public IActionResult RemoveRange(SimpleTable[] simpleTables)
        {
            context.SimpleTables.RemoveRange(simpleTables);
            context.SaveChanges();
            return Ok("Silme İşlemi Başarılı!");
        }

    }
}
