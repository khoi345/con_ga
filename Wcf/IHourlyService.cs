using Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Wcf;
using System.ServiceModel.Activation;
using System.Threading;
using System.Linq;
using System.Timers;
using System.ServiceModel.Web;

namespace Wcf
{
    [ServiceContract]
    public interface IHourlyService
    {

        [OperationContract]

        [WebInvoke(Method = "GET", UriTemplate = "DoHourlyTask", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Xml)]
        string DoHourlyTask();


    }
}