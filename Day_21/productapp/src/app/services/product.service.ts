import { Product } from "../product/product";


export class ProductService{
  products:Product[];
  constructor(){
      this.products =[
        new Product(1,"Cell",24,6),
        new Product(2,"Fridge",41,5)
      ];
    }
    getProducts(){
      return this.products;
    }

    addProduct(product:Product){
      this.products.push(product);
    }


    // deleteEmployee(eid:number){
    //   var eidx;
    //   for (let index = 0; index < this.employees.length; index++) {
    //           if(this.employees[index].id==eid)
    //           {
    //               eidx = index;
    //               break;
    //           }
    //   }
    //   console.log(this.employees[eidx??0]);
    //   this.employees.splice(eidx??-1,1)
    // }

    getProduct(pid:number):any{
      var pidx:number=-1;
      for (let index = 0; index < this.products.length; index++) {
              if(this.products[index].id==pid)
              {
                  pidx = index;
                  break;
              }
      }
      if(pidx != -1)
          return this.products[pidx];
    }
}