import { CartItems } from "./cart"

export class OrderRequestDto {


    constructor( public id:number=0,
      
        public totalProductQuantity:number=0,
        public totalPrice:number=0,
        public username:string="",
        public addressId:number=0,      
        public listofItems:CartItems[]=[],
       
        
        
        ){

    }


   
}

