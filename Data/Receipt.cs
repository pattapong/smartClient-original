using System;
using System.Collections;
using System.Windows.Forms;
using smartRestaurant.CheckBillService;
using smartRestaurant.MenuService;
using smartRestaurant.OrderService;
using smartRestaurant.PaymentService;

namespace smartRestaurant.Data
{
	/// <summary>
	/// Summary description for Receipt.
	/// </summary>
	public class Receipt
	{
		private static PaymentMethod[] paymentMethods;
		private static PromotionCard[] coupons;
		private static PromotionCard[] giftVouchers;
		private static Discount[] discounts;

		private MenuType[]	menuTypes;
		private OrderBill	selectedBill;

		// Invoice data
		private int employeeID;
		private int invoiceID;
		private int orderBillID;
		// Summary
		private double	amountDue;
		private double	tax1;
		private double	tax2;
		private double	totalDiscount;
		private double	totalDue;
		private double	totalReceive;
		private double	change;
		// Payment
		private ArrayList		useDiscount;
		private PaymentMethod	paymentMethod;
		private double			payValue;
		private ArrayList		paymentMethodList;	// PaymentMethod[]
		private ArrayList		payValueList;		// double[]
		private	int				pointAmount;
		private PromotionCard	coupon;
		private PromotionCard	giftVoucher;

		public Receipt(OrderBill bill, int employeeID)
		{
			this.selectedBill = bill;
			menuTypes = MenuManagement.MenuTypes;
			totalReceive = 0;

			this.paymentMethod = null;
			this.paymentMethodList = new ArrayList();
			this.payValueList = new ArrayList();
			coupon = null;
			giftVoucher = null;
			useDiscount = new ArrayList();
			this.employeeID = employeeID;

			//** Load Invoice
			invoiceID = 0;
			LoadInvoice();
		}

		public Receipt(int invoiceID)
		{
			this.selectedBill = null;
			totalReceive = 0;

			this.paymentMethod = null;
			this.paymentMethodList = new ArrayList();
			this.payValueList = new ArrayList();
			coupon = null;
			giftVoucher = null;
			useDiscount = new ArrayList();

			//** Load Invoice
			this.invoiceID = invoiceID;
			LoadInvoice();
		}

		public void ClearPaymentMethod()
		{
			paymentMethodList.Clear();
			payValueList.Clear();
		}

		public void SetPaymentMethod(PaymentMethod method, double val)
		{
			if (method == null)
			{
				paymentMethodList.Clear();
				payValueList.Clear();
			}
			else
			{
				int pos = this.paymentMethodList.IndexOf(method);
				if (val != 0)
				{
					// Set new value
					if (pos >= 0)
						payValueList[pos] = val;
					else
					{
						paymentMethodList.Add(method);
						payValueList.Add(val);
					}
				}
				else
				{
					// Clear value
					if (pos >= 0)
					{
						paymentMethodList.RemoveAt(pos);
						payValueList.RemoveAt(pos);
					}
				}
			}
			payValue = 0;
			for (int i = 0;i < payValueList.Count;i++)
				payValue += (double)payValueList[i];
			totalReceive = payValue;
			paymentMethod = null;
		}

		private Invoice CreateInvoice()
		{
			Invoice invoice;
			invoice = new Invoice();
			invoice.invoiceID = invoiceID;
			if (paymentMethod != null)
				invoice.paymentMethodID = paymentMethod.paymentMethodID;
			else
				invoice.paymentMethodID = PaymentMethods[0].paymentMethodID;
			if (selectedBill != null)
				invoice.orderBillID = selectedBill.OrderBillID;
			else
				invoice.orderBillID = orderBillID;
			invoice.point = pointAmount;
			invoice.totalPrice = amountDue;
			invoice.tax1 = tax1;
			invoice.tax2 = tax2;
			invoice.totalDiscount = totalDiscount;
			invoice.totalReceive = totalReceive;
			invoice.employeeID = this.employeeID;
			invoice.refInvoice = 0;
			invoice.discounts = null;
			if (useDiscount.Count > 0)
			{
				invoice.discounts = new InvoiceDiscount[useDiscount.Count];
				for (int i = 0;i < useDiscount.Count;i++)
				{
					invoice.discounts[i] = new InvoiceDiscount();
					invoice.discounts[i].promotionID = ((Discount)useDiscount[i]).promotionID;
				}
			}
			invoice.payments = null;
			if (paymentMethodList.Count > 0)
			{
				invoice.payments = new InvoicePayment[paymentMethodList.Count];
				for (int i = 0;i < paymentMethodList.Count;i++)
				{
					invoice.payments[i] = new InvoicePayment();
					invoice.payments[i].paymentMethodID = ((PaymentService.PaymentMethod)paymentMethodList[i]).paymentMethodID;
					invoice.payments[i].receive = (double)payValueList[i];
				}
			}
			return invoice;
		}

		private void LoadInvoice()
		{
			CheckBillService.CheckBillService service = new CheckBillService.CheckBillService();
			Invoice invoice;
			if (invoiceID == 0)
				invoice = service.GetInvoice(selectedBill.OrderBillID);
			else
				invoice = service.GetInvoiceByID(invoiceID);
			if (invoice != null)
			{
				if (invoice.invoiceID == 0)
				{
					MessageBox.Show("Can't load invoice data");
					return;
				}
				invoiceID = invoice.invoiceID;
				paymentMethod = null;
				if (Receipt.PaymentMethods != null)
				{
					for (int i = 0;i < PaymentMethods.Length;i++)
						if (PaymentMethods[i].paymentMethodID == invoice.paymentMethodID)
						{
							paymentMethod = PaymentMethods[i];
							break;
						}
				}
				if (selectedBill == null)
				{
					employeeID = invoice.employeeID;
					orderBillID = invoice.orderBillID;
				}
				amountDue = invoice.totalPrice;
				pointAmount = invoice.point;
				tax1 = invoice.tax1;
				tax2 = invoice.tax2;
				totalDiscount = invoice.totalDiscount;
				totalReceive = invoice.totalReceive;
				totalDue = amountDue + tax1 + tax2 - totalDiscount;
				// Feed discount
				useDiscount.Clear();
				if (invoice.discounts != null)
				{
					for (int i = 0;i < invoice.discounts.Length;i++)
					{
						for (int j = 0;j < Discounts.Length;j++)
						{
							if (Discounts[j].promotionID == invoice.discounts[i].promotionID)
							{
								useDiscount.Add(Discounts[j]);
								break;
							}
						}
					}
				}
				// Feed payment
				paymentMethodList.Clear();
				payValueList.Clear();
				if (invoice.payments != null)
				{
					for (int i = 0;i < invoice.payments.Length;i++)
					{
						for (int j = 0;j < PaymentMethods.Length;j++)
						{
							if (PaymentMethods[j].paymentMethodID == invoice.payments[i].paymentMethodID)
							{
								paymentMethodList.Add(PaymentMethods[j]);
								payValueList.Add(invoice.payments[i].receive);
								break;
							}
						}
					}
				}
				//payValue = 0
			}
			else
				SendInvoice(false, false);
		}

		public bool SendInvoice(bool closed, bool print)
		{
			CheckBillService.CheckBillService service = new CheckBillService.CheckBillService();
			Invoice invoice = CreateInvoice();
			if (!closed)
				invoice.totalReceive = 0;
			string msg = service.SendInvoice(invoice);
			try
			{
				invoiceID = Int32.Parse(msg);
			}
			catch (Exception)
			{
				MessageBox.Show(msg);
				return true;
			}
			if (!closed && invoiceID == -1)
				return false;
			if (print)
			{
				OrderService.OrderService oService = new OrderService.OrderService();
				if (closed)
					oService.PrintBill(invoice.orderBillID);
				else
					oService.PrintReceipt(invoice.orderBillID);
			}
			if (invoiceID == -1)
				return false;
			return true;
		}

		public void PrintInvoice()
		{
			Invoice invoice = CreateInvoice();
			OrderService.OrderService oService = new OrderService.OrderService();
			oService.ReprintBill(invoice.orderBillID);
		}

		public void Compute()
		{
			// Reset value
			totalDue = 0;
			// Compute discount
			double discountAmt = 0;
			double discountPer = 0;
			if (useDiscount.Count > 0)
			{
				for (int i = 0;i < useDiscount.Count;i++)
				{
					Discount dis = (Discount)useDiscount[i];
					if (dis.discountPercent > 0)
						discountPer += dis.discountPercent;
					else if (dis.discountAmount > 0)
						discountAmt += dis.discountAmount;
				}
			}
			// Get compute price and tax from web service
			if (selectedBill != null && selectedBill.Items != null)
			{
				CheckBillService.CheckBillService service = new CheckBillService.CheckBillService();
				BillPrice price = service.GetComputeBillPrice(selectedBill.OrderBillID);
				amountDue = price.totalPrice;
				totalDiscount = price.totalDiscount;
				tax1 = price.totalTax1;
				tax2 = price.totalTax2;
			}
			else if (selectedBill != null)
			{
				totalDiscount = discountAmt;
				amountDue = tax1 = tax2 = 0;
			}
			totalDue = amountDue - totalDiscount + tax1 + tax2;
			/*totalDiscount = (totalDue * discountPer / 100.0) + discountAmt;
			totalDue -= totalDiscount;*/
			// Payment
			double totalValue = 0;
			for (int i = 0;i < payValueList.Count;i++)
				totalValue += (double)payValueList[i];
			totalReceive = totalValue + PointValue + CouponValue + GiftVoucherValue;
			// Change
			if (totalDue < 0)
				totalDue = 0;
			change = totalReceive - totalDue;
			if (change < 0.0)
				change = 0.0;
		}

		public void UseDiscountAdd(Discount dis)
		{
			UseDiscount.Add(dis);
			SendInvoice(false, false);
		}

		public void UseDiscountRemove(Discount dis)
		{
			UseDiscount.Remove(dis);
			SendInvoice(false, false);
		}

		public static void PrintReceiptAll(OrderInformation orderInfo)
		{
			OrderService.OrderService oService = new OrderService.OrderService();
			for (int i = 0;i < orderInfo.Bills.Length;i++)
			{
				if (orderInfo.Bills[i].Items != null &&
					orderInfo.Bills[i].Items.Length > 0 &&
					orderInfo.Bills[i].CloseBillDate == DateTime.MinValue)
					oService.PrintReceipt(orderInfo.Bills[i].OrderBillID);
			}
		}

		public static Discount SearchDiscountByID(int id)
		{
			for (int i = 0;i < discounts.Length;i++)
				if (discounts[i].promotionID == id)
					return discounts[i];
			return null;
		}

		public static PaymentMethod SearchPaymentMethodByID(int id)
		{
			for (int i = 0;i < paymentMethods.Length;i++)
				if (paymentMethods[i].paymentMethodID == id)
					return paymentMethods[i];
			return null;
		}

		public static PaymentMethod[] PaymentMethods
		{
			get
			{
				if (paymentMethods == null)
					paymentMethods = (new PaymentService.PaymentService()).GetPaymentMethods();
				return paymentMethods;
			}
		}

		public static PromotionCard[] Coupons
		{
			get
			{
				if (coupons == null)
					coupons = (new PaymentService.PaymentService()).GetCoupons();
				return coupons;
			}
		}

		public static PromotionCard[] GiftVouchers
		{
			get
			{
				if (giftVouchers == null)
					giftVouchers = (new PaymentService.PaymentService()).GetGiftVouchers();
				return giftVouchers;
			}
		}

		public static Discount[] Discounts
		{
			get
			{
				if (discounts == null)
					discounts = (new PaymentService.PaymentService()).GetDiscounts();
				return discounts;
			}
		}

		public double AmountDue
		{
			get
			{
				return amountDue;
			}
		}

		public double Tax1
		{
			get
			{
				return tax1;
			}
		}

		public double Tax2
		{
			get
			{
				return tax2;
			}
		}

		public double TotalDiscount
		{
			get
			{
				return totalDiscount;
			}
		}

		public double TotalDue
		{
			get
			{
				return totalDue;
			}
		}

		public double TotalReceive
		{
			get
			{
				return totalReceive;
			}
			set
			{
				totalReceive = value;
			}
		}

		public double Change
		{
			get
			{
				return change;
			}
		}

		public PaymentMethod PaymentMethod
		{
			get
			{
				return paymentMethod;
			}
			set
			{
				paymentMethod = value;
			}
		}

		public double PayValue
		{
			get
			{
				return payValue;
			}
			set
			{
				payValue = value;
			}
		}

		public ArrayList PaymentMethodList
		{
			get
			{
				return paymentMethodList;
			}
			set
			{
				paymentMethodList = value;
			}
		}

		public ArrayList PayValueList
		{
			get
			{
				return payValueList;
			}
			set
			{
				payValueList = value;
			}
		}

		public int PointAmount
		{
			get
			{
				return pointAmount;
			}
			set
			{
				pointAmount = value;
			}
		}

		public double PointValue
		{
			get
			{
				return (double)pointAmount / 100.0;
			}
		}

		public PromotionCard Coupon
		{
			get
			{
				return coupon;
			}
			set
			{
				coupon = value;
			}
		}

		public double CouponValue
		{
			get
			{
				if (coupon != null)
					return coupon.amount;
				else
					return 0.0;
			}
		}

		public PromotionCard GiftVoucher
		{
			get
			{
				return giftVoucher;
			}
			set
			{
				giftVoucher = value;
			}
		}

		public ArrayList UseDiscount
		{
			get
			{
				return useDiscount;
			}
		}

		public double GiftVoucherValue
		{
			get
			{
				if (giftVoucher != null)
					return giftVoucher.amount;
				else
					return 0.0;
			}
		}

		public bool IsCompleted
		{
			get
			{
				return ((long)(totalReceive * 100.0) >= (long)(totalDue * 100.0));
			}
		}
	}
}
