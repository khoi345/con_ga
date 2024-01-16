using Dto;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Wcf
{
    [ServiceContract]
    public interface IFLTService
    {
       
        [OperationContract]

        [WebInvoke(Method = "GET", UriTemplate = "Hello", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Xml)]
        string Hello();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        KetQua Post(_Dto json);
    }
}