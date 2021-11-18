var orders = new List<string>();

foreach (var OrderLine in from ol in ttPickedOrders
                where ol.Company == Session.CompanyID
                select ol){
              
      var isHold = (from ld in Db.OrderDtl
              where ld.Company == Session.CompanyID
              && ld.OrderNum == OrderLine.OrderNum
              && ld.OrderLine == OrderLine.OrderLine
              select ld).FirstOrDefault();
 
      if (isHold.LineHold_c == true){
            orders.Add(isHold.OrderNum+"/"+isHold.OrderLine);
                    
 
 }
 }
 
List<string> unique = orders.Distinct().ToList();
string ordernumbers = string.Join(", ",unique); 

 if (ordernumbers.Length > 0){
 isHold2 = true;
 Message = "The following orders are on hold: "+ordernumbers;
 }

//#Then do a condition for if isHold is true or not and if it is true throw an exception with the Message
