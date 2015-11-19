﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
// 
namespace smartRestaurant.UserAuthorizeService {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="UserAuthorizeServiceSoap", Namespace="http://ws.smartRestaurant.net")]
    public class UserAuthorizeService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public UserAuthorizeService() {
            string urlSetting = System.Configuration.ConfigurationSettings.AppSettings["smartRestaurant.UserAuthorizeService.UserAuthorizeService"];
            if ((urlSetting != null)) {
                this.Url = string.Concat(urlSetting, "");
            }
            else {
                this.Url = "http://localhost/smartService/UserAuthorizeService.asmx";
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/CheckLogin", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UserProfile CheckLogin(int employeeID, string password) {
            object[] results = this.Invoke("CheckLogin", new object[] {
                        employeeID,
                        password});
            return ((UserProfile)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckLogin(int employeeID, string password, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckLogin", new object[] {
                        employeeID,
                        password}, callback, asyncState);
        }
        
        /// <remarks/>
        public UserProfile EndCheckLogin(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((UserProfile)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/CheckLogout", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckLogout(int employeeID) {
            object[] results = this.Invoke("CheckLogout", new object[] {
                        employeeID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckLogout(int employeeID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckLogout", new object[] {
                        employeeID}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCheckLogout(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class UserProfile {
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public int EmployeeTypeID;
    }
}