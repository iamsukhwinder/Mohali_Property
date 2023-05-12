using Mohali_Property_Model;

namespace Mohali_Property_Web.APICall.Admin.ManageKothi
{
    public interface IManageKothi
    {
        public Task<List<KothiModel>> getkothieslist();
        public  Task<int> Add_Kothi(KothiModel kothiModel);
        
            public Task<KothiModel>Edit_kothi(int id);

        public Task<int> update_kothi(KothiModel obj);
        public Task<int> delete_kothi(int id);

    }
}
