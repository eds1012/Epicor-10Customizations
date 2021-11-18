foreach (var OrderLine in from ol in ttShipDtl
                where ol.Company == Session.CompanyID
                select ol){
              
var isHold = (from ld in Db.OrderDtl
              where ld.Company == Session.CompanyID
              && ld.OrderNum == OrderLine.OrderNum
              && ld.OrderLine == orderLine
              select ld).FirstOrDefault();
 
      if (isHold.LineHold_c == true){
            
                    CallContext.Current.ExceptionManager.AddBLException("Line Number: "+isHold.OrderLine+" is on hold and can not be shipped.");
 
 
 }
 }
