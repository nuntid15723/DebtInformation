using DebtInformation.Models;
namespace DebtInformation.Service
{
    public class InformationService
    {
        List<Informations_test> infodetails = new List<Informations_test>(){
    //new Informations(){coop_id ="1",memcoop_id = "ntre1",member_no = "123",deptaccount_name="pptyas1"},
    //new Informations(){coop_id ="2",memcoop_id = "ntre2",member_no = "1234",deptaccount_name="pptyas2"},
    //new Informations(){coop_id ="3",memcoop_id = "ntre3",member_no = "12345",deptaccount_name="pptyas3"},
    //new Informations(){coop_id ="4",memcoop_id = "ntre4",member_no = "123456",deptaccount_name="pptyas4"},
    //new Informations(){coop_id ="5",memcoop_id = "ntre5",member_no = "1234567",deptaccount_name="pptyas5"},
    };
        public async Task<List<Informations_test>> InformationList()
        {
            return await Task.FromResult(infodetails);

        }
    }
}