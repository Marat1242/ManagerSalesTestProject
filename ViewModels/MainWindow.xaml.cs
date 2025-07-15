using System.Windows;
using ManagerSalesTestProject.Models;
using ManagerSalesTestProject.Services;

namespace ManagerSalesTestProject;


public partial class MainWindow : Window
{
    private readonly DataService _dataService;
    public MainWindow()
    {
        InitializeComponent();
        _dataService = new DataService(new ManagerSalesTestProjectContext());

        LoadAllEquipment();

    }

    private async void LoadAllEquipment()
    {
        try
        {
            var equipmentList = await _dataService.GetAllEquipmentAsync();
            EquipmentGrid.ItemsSource = equipmentList;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке");
        }
    }
    private void LoadClick(object sender, RoutedEventArgs e)
    {
        LoadAllEquipment();
    }
    private async void AddClick(object sender, RoutedEventArgs e)
    {
        try
        {
            await _dataService.AddEquipmentAsync(new EquipmentModel
            {

                Name = "New Equipment",
                Type = EquipmentType.Monitor,
                Status = EquipmentStatus.InWareHouse
            });
            LoadAllEquipment();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при поиске");
        }



    }
    private async void UpdateClick(object sender, RoutedEventArgs e)
    {

        if (EquipmentGrid.SelectedItem is EquipmentModel selected)
        {

            var updated = new EquipmentModel(

                selected.Id,
                selected.Name,
                selected.Type,
                selected.Status
            );
            await _dataService.UpdateEquipmentAsync(updated);
            LoadAllEquipment();
        }
    }
    private async void DeleteClick(object sender, RoutedEventArgs e)
    {
        if (EquipmentGrid.SelectedItem is EquipmentModel selected)
        {
            await _dataService.DeleteEquipmentAsync(selected.Id);
            LoadAllEquipment();
        }
    }
}

