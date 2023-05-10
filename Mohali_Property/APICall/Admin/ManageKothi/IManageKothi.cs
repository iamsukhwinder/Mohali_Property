using Mohali_Property_Model;

namespace Mohali_Property_Web.APICall.Admin.ManageKothi
{
    public interface IManageKothi
    {
        public Task<List<KothiModel>> getkothieslist();

    }
}
