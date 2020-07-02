# How-to-create-Chart-in-F-Sharp-WPF

This example explains how to create a SfChart in WPF using the [F#](https://docs.microsoft.com/en-us/dotnet/fsharp/what-is-fsharp).Please refer KB links for more details,

[How to create Chart in F#?](https://www.syncfusion.com/kb/11663/how-to-create-chart-in-f-wpf)

Let us see the simple example of displaying expense report in WPF chart using the F# ([MVVM Pattern](https://docs.microsoft.com/en-us/archive/msdn-magazine/2011/september/fsharp-programming-build-mvvm-applications-in-fsharp)) by following these steps:

Step 1: Create a model F# code for a simple Expense model with fields for XValue and YValue.

**C#**
```
namespace FSharpWpfMvvmTemplate.Model

type ExpenseReport =
    { 
	XValue : string
       YValue : string

      }
```
Step 2: Populate the Expense model properties in Repository.

**C#**
```
namespace FSharpWpfMvvmTemplate.Repository

open FSharpWpfMvvmTemplate.Model

type ExpenseReportRepository() =
    member x.GetAll() =
        seq{ 
		yield {XValue="Adidas" 
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
```
Step 3: Inheriting from a C# ViewModelBase class, which give the Repository as ObservableCollection.

**C#**
```
type ExpenseItHomeViewModel(expenseReportRepository : ExpenseReportRepository) =   
    inherit ViewModelBase()
   
    new () = ExpenseItHomeViewModel(ExpenseReportRepository())
    member x.ExpenseReports = 
        new ObservableCollection<ExpenseReport>(
            expenseReportRepository.GetAll())
```
Step 4: Create and add a SfChart to UserControl. Set the Binding to ItemSource, XBindingPath and YBindingPath properties of series, respectively.

**XAML**
```
<UserControl xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"      
             xmlns:ViewModel="clr-
                    namespace:FSharpWpfMvvmTemplate.ViewModel;assembly=App"       
             mc:Ignorable="d"    
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"             
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:chart="clr-
             namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF"
             d:DesignWidth="424">
    <UserControl.DataContext>
        <ViewModel:ExpenseItHomeViewModel/>                   
    </UserControl.DataContext>
    
    <Grid>
        <chart:SfChart Margin="10" >
            <chart:SfChart.Header>
                <TextBlock Text="Sneakers Sold by Brand for three months" FontSize="16"    
                           FontWeight="Bold"/>
            </chart:SfChart.Header>
            <chart:SfChart.PrimaryAxis>
                <chart:CategoryAxis Header="Brand"/>
            </chart:SfChart.PrimaryAxis>
            <chart:SfChart.SecondaryAxis>
                <chart:NumericalAxis Maximum="50" Header="Number of items sold(in %)"/>
            </chart:SfChart.SecondaryAxis>
            <chart:ColumnSeries Palette="Metro" ItemsSource="{Binding ExpenseReports}" 
                                 XBindingPath="XValue" YBindingPath="YValue"/>
        </chart:SfChart>
    </Grid>
</UserControl>
```
Step 5: Add UserControl with SfChart in the MainWindow.xaml using the Frame.

**XAML**
```
<Window
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="ExpenseIt" Height="450" Width="500">
    <Frame Source="ExpenseItHome.xaml" />
</Window>
```


