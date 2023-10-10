import { CartItems } from "./cart";
import { UserAddress } from "./useraddress";

export class OrderResponseDto {


    constructor( 
        public orderId:number=0,
        // public proPic:string="",
        public totalProductQuantity:number=0,
        public totalPrice:number=0,
        public username:string="",
        public addressId:string="",
        public listofItems:CartItems[]=[],
        public userAddress:UserAddress=new UserAddress(),
        )
        {


    }


   
}

