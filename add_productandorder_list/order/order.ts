export class Order {
    constructor(
      public id:number=0,
      public productQuantity:number=0,
       public dateTime:Date = new Date(),
      public orderDate:Date = new Date(),
      public totalPrice:number=0,
      public username:string=""
    ) {}
  }