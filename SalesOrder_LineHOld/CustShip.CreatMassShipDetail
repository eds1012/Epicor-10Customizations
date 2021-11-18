This needs to be added as a pre-processing to the Method CustShip.CreateMassShipDetail to block users from shipping an order line that is on hold through the mass shipping function


```
var orderlines = new List<int>();
var OrderDtl = (from od in Db.OrderDtl
          where od.OrderNum == orderNum
          select od);
  foreach (var line in OrderDtl){
      if(line.LineHold_c == true){
        orderlines.Add(line.OrderLine);
        }
    } 
    
List<int> unique = orderlines.Distinct().ToList();
string ordernumbers = string.Join(", ",unique);

if (ordernumbers.Length > 0){
 CallContext.Current.ExceptionManager.AddBLException("The following Lines are on hold: "+ordernumbers);
}
```
