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
namespace smartRestaurant.OrderService {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="OrderServiceSoap", Namespace="http://ws.smartRestaurant.net")]
    public class OrderService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public OrderService() {
            string urlSetting = System.Configuration.ConfigurationSettings.AppSettings["smartRestaurant.OrderService.OrderService"];
            if ((urlSetting != null)) {
                this.Url = string.Concat(urlSetting, "");
            }
            else {
                this.Url = "http://localhost/smartService/OrderService.asmx";
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/GetOrder", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderInformation GetOrder(int tableID) {
            object[] results = this.Invoke("GetOrder", new object[] {
                        tableID});
            return ((OrderInformation)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetOrder(int tableID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetOrder", new object[] {
                        tableID}, callback, asyncState);
        }
        
        /// <remarks/>
        public OrderInformation EndGetOrder(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((OrderInformation)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/GetOrderByOrderID", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderInformation GetOrderByOrderID(int OrderID) {
            object[] results = this.Invoke("GetOrderByOrderID", new object[] {
                        OrderID});
            return ((OrderInformation)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetOrderByOrderID(int OrderID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetOrderByOrderID", new object[] {
                        OrderID}, callback, asyncState);
        }
        
        /// <remarks/>
        public OrderInformation EndGetOrderByOrderID(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((OrderInformation)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/GetTableReference", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int[] GetTableReference(int orderID) {
            object[] results = this.Invoke("GetTableReference", new object[] {
                        orderID});
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTableReference(int orderID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetTableReference", new object[] {
                        orderID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int[] EndGetTableReference(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/SetTableReference", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SetTableReference(int orderID, int[] tableIDList) {
            object[] results = this.Invoke("SetTableReference", new object[] {
                        orderID,
                        tableIDList});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSetTableReference(int orderID, int[] tableIDList, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SetTableReference", new object[] {
                        orderID,
                        tableIDList}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndSetTableReference(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/SendOrder", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendOrder(OrderInformation orderInfo, string CustFullName) {
            object[] results = this.Invoke("SendOrder", new object[] {
                        orderInfo,
                        CustFullName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendOrder(OrderInformation orderInfo, string CustFullName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendOrder", new object[] {
                        orderInfo,
                        CustFullName}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndSendOrder(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/SendOrderPrint", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendOrderPrint(OrderInformation orderInfo, string CustFullName, bool print) {
            object[] results = this.Invoke("SendOrderPrint", new object[] {
                        orderInfo,
                        CustFullName,
                        print});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendOrderPrint(OrderInformation orderInfo, string CustFullName, bool print, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendOrderPrint", new object[] {
                        orderInfo,
                        CustFullName,
                        print}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndSendOrderPrint(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/SendOrderBill", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendOrderBill(OrderBill Bill) {
            object[] results = this.Invoke("SendOrderBill", new object[] {
                        Bill});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendOrderBill(OrderBill Bill, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendOrderBill", new object[] {
                        Bill}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndSendOrderBill(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/GetTakeOutList", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TakeOutInformation[] GetTakeOutList() {
            object[] results = this.Invoke("GetTakeOutList", new object[0]);
            return ((TakeOutInformation[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTakeOutList(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetTakeOutList", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public TakeOutInformation[] EndGetTakeOutList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((TakeOutInformation[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/PrintReceipt", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int PrintReceipt(int OrderBillID) {
            object[] results = this.Invoke("PrintReceipt", new object[] {
                        OrderBillID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPrintReceipt(int OrderBillID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("PrintReceipt", new object[] {
                        OrderBillID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndPrintReceipt(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/PrintBill", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int PrintBill(int OrderBillID) {
            object[] results = this.Invoke("PrintBill", new object[] {
                        OrderBillID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPrintBill(int OrderBillID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("PrintBill", new object[] {
                        OrderBillID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndPrintBill(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/ReprintBill", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int ReprintBill(int OrderBillID) {
            object[] results = this.Invoke("ReprintBill", new object[] {
                        OrderBillID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginReprintBill(int OrderBillID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ReprintBill", new object[] {
                        OrderBillID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndReprintBill(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/GetCancelReason", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CancelReason[] GetCancelReason() {
            object[] results = this.Invoke("GetCancelReason", new object[0]);
            return ((CancelReason[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCancelReason(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCancelReason", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public CancelReason[] EndGetCancelReason(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((CancelReason[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/GetBillDetailWaitingList", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderWaiting[] GetBillDetailWaitingList() {
            object[] results = this.Invoke("GetBillDetailWaitingList", new object[0]);
            return ((OrderWaiting[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetBillDetailWaitingList(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetBillDetailWaitingList", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public OrderWaiting[] EndGetBillDetailWaitingList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((OrderWaiting[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.smartRestaurant.net/ServeWaitingOrder", RequestNamespace="http://ws.smartRestaurant.net", ResponseNamespace="http://ws.smartRestaurant.net", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderWaiting[] ServeWaitingOrder(int orderID, int billDetailID) {
            object[] results = this.Invoke("ServeWaitingOrder", new object[] {
                        orderID,
                        billDetailID});
            return ((OrderWaiting[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginServeWaitingOrder(int orderID, int billDetailID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ServeWaitingOrder", new object[] {
                        orderID,
                        billDetailID}, callback, asyncState);
        }
        
        /// <remarks/>
        public OrderWaiting[] EndServeWaitingOrder(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((OrderWaiting[])(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class OrderInformation {
        
        /// <remarks/>
        public int OrderID;
        
        /// <remarks/>
        public System.DateTime OrderTime;
        
        /// <remarks/>
        public int TableID;
        
        /// <remarks/>
        public int EmployeeID;
        
        /// <remarks/>
        public int NumberOfGuest;
        
        /// <remarks/>
        public System.DateTime CloseOrderDate;
        
        /// <remarks/>
        public System.DateTime CreateDate;
        
        /// <remarks/>
        public OrderBill[] Bills;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class OrderBill {
        
        /// <remarks/>
        public int OrderBillID;
        
        /// <remarks/>
        public int BillID;
        
        /// <remarks/>
        public int EmployeeID;
        
        /// <remarks/>
        public System.DateTime CloseBillDate;
        
        /// <remarks/>
        public OrderBillItem[] Items;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class OrderBillItem {
        
        /// <remarks/>
        public int BillDetailID;
        
        /// <remarks/>
        public int MenuID;
        
        /// <remarks/>
        public int Unit;
        
        /// <remarks/>
        public bool DefaultOption;
        
        /// <remarks/>
        public System.Byte Status;
        
        /// <remarks/>
        public string Message;
        
        /// <remarks/>
        public System.DateTime ServeTime;
        
        /// <remarks/>
        public int CancelReasonID;
        
        /// <remarks/>
        public int EmployeeID;
        
        /// <remarks/>
        public bool ChangeFlag;
        
        /// <remarks/>
        public OrderItemChoice[] ItemChoices;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class OrderItemChoice {
        
        /// <remarks/>
        public int OptionID;
        
        /// <remarks/>
        public int ChoiceID;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class OrderBillItemWaiting {
        
        /// <remarks/>
        public int BillDetailID;
        
        /// <remarks/>
        public string MenuKeyID;
        
        /// <remarks/>
        public int Unit;
        
        /// <remarks/>
        public string Choice;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class OrderWaiting {
        
        /// <remarks/>
        public int OrderID;
        
        /// <remarks/>
        public string TableName;
        
        /// <remarks/>
        public OrderBillItemWaiting[] Items;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class CancelReason {
        
        /// <remarks/>
        public int CancelReasonID;
        
        /// <remarks/>
        public string Reason;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class CustomerInformation {
        
        /// <remarks/>
        public int CustID;
        
        /// <remarks/>
        public string FirstName;
        
        /// <remarks/>
        public string MiddleName;
        
        /// <remarks/>
        public string LastName;
        
        /// <remarks/>
        public string Telephone;
        
        /// <remarks/>
        public string Address;
        
        /// <remarks/>
        public string Description;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.smartRestaurant.net")]
    public class TakeOutInformation {
        
        /// <remarks/>
        public int OrderID;
        
        /// <remarks/>
        public CustomerInformation CustInfo;
    }
}
