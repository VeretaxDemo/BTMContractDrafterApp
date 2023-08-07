using BTMContractDrafter.Models;
//using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace BTMContractDrafter.ViewModels;

public class AddUnitViewModel : ViewModelBase
{
    private ObservableCollection<UnitSize> _unitSizes;
    private Unit _selectedUnit;

    public ObservableCollection<UnitSize> UnitSizes
    {
        get { return _unitSizes; }
        set
        {
            _unitSizes = value;
            OnPropertyChanged(nameof(UnitSizes)); // Notify property change when the collection is set
        }
    }

    public Unit SelectedUnit
    {
        get { return _selectedUnit; }
        set
        {
            _selectedUnit = value;
            OnPropertyChanged(nameof(SelectedUnit)); // Notify property change when the selected unit is set
        }
    }

    public AddUnitViewModel(ObservableCollection<UnitSize> unitSizes)
    {
        // Convert the list of UnitSize objects to a list of strings
        UnitSizes = unitSizes;

        // Create a new Unit instance to bind to the view
        SelectedUnit = new Unit();
    }
}