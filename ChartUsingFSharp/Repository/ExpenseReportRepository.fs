namespace FSharpWpfMvvmTemplate.Repository

open FSharpWpfMvvmTemplate.Model

type ExpenseReportRepository() =
    member x.GetAll() =
        seq{ yield {XValue="Adidas" 
                    YValue="10"
                   }
             yield {XValue="Niki"
                    YValue="30" 
                   }    
             yield {XValue="Reebok" 
                    YValue="40"
                   }
             yield {XValue="Fila"
                    YValue="20"
                   }
             yield {XValue="Puma" 
                    YValue="15"
                   }

           }
