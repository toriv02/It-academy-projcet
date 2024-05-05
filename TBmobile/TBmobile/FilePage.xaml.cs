using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilePage : ContentPage
    {
        private string selectedFilePath;
        public FilePage()
        {
            InitializeComponent();
        }
        private async void ButtonAddFile(object sender, EventArgs e)
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.StorageRead>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var result = await FilePicker.PickAsync(new PickOptions
                    {
                        PickerTitle = "Выберите файл",
                        FileTypes = FilePickerFileType.Pdf,
                    });

                    if (result != null)
                    {
                        if (!result.FileName.EndsWith(".jpg") && !result.FileName.EndsWith(".jpeg") && !result.FileName.EndsWith(".png"))
                        {
                            selectedFilePath = result.FullPath;
                            // Сохранение выбранного файла в переменную selectedFilePath
                        }
                        else
                        {
                            await DisplayAlert("Ошибка", "Выберите файл, отличный от фото", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Ошибка", "Разрешение на доступ к файлам не предоставлено", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}