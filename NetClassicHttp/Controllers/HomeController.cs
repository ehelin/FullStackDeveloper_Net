using System.Web.Http;
using System.Web.Mvc;
using NetClassicMvc = System.Web.Mvc;

namespace NetClassicHttp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [NetClassicMvc.Route("deleteThatRecord")]
        [NetClassicMvc.HttpDelete]
        public void DeleteThatRecord()
        {
            var IAmARecordToBeDeleted = 1;
        }
        
        [NetClassicMvc.Route("deleteThatRecordWithId/{int:id}")]
        [NetClassicMvc.HttpDelete]
        public void DeleteThatRecordWithId(int id)
        {
            var IAmARecordToBeDeleted = id;
        }

        [NetClassicMvc.Route("deleteThatRecordWithIdArray")]
        [NetClassicMvc.HttpDelete]
        public void DeleteThatRecordWithIdArray([FromUri]int[] ids)
        {
            var IAmARecordToBeDeleted = ids;
        }

        // Does not seem to work...404
        [NetClassicMvc.Route("deleteThatRecordWithBody")]
        [NetClassicMvc.HttpDelete]
        public void DeleteThatRecordWithIdBody([FromBody]int id)
        {
            var IAmARecordToBeDeleted = id;
        }

        [NetClassicMvc.Route("deleteThatRecordWithIdBodyUsingHttpPost")]
        [NetClassicMvc.HttpPost]
        public void DeleteThatRecordWithIdBodyUsingHttpPost([FromBody]int id)
        {
            var IAmARecordToBeDeleted = id;
        }

        [NetClassicMvc.Route("deleteThatRecordWithIdArrayBodyUsingHttpPost")]
        [NetClassicMvc.HttpPost]
        public void AeleteThatRecordWithIdArrayBodyUsingHttpPost([FromBody]int id, [FromBody]int[] ids)
        {
            var IAmARecordToBeDeleted = id;
        }

        [NetClassicMvc.Route("deleteThatRecordWithIdComplexObjectBodyUsingHttpPost")]
        [NetClassicMvc.HttpPost]
        public void DeleteThatRecordWithIdComplexObjectBodyUsingHttpPost([FromBody]int id, [FromBody]ParamObject[] ids)
        {
            var IAmARecordToBeDeleted = id;
        }
    }

    public class ParamObject
    {
        public int ParamObjectId1 { get; set; }
        public int ParamObjectId2 { get; set; }
    }
}