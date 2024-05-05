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
    public partial class PicturePage : ContentPage
    {
        private string selectedImagePath;
        public PicturePage()
        {
            InitializeComponent();
        }
        private async void ButtonAddImage(object sender, EventArgs e)
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.Photos>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.Photos>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                    {
                        Title = "Выберите фото"
                    });

                    if (result != null)
                    {
                        selectedImagePath = result.FullPath;
                        // Сохранение выбранного пути к изображению в переменную selectedImagePath
                    }
                }
                else
                {
                    await DisplayAlert("Ошибка", "Разрешение на доступ к фото не предоставлено", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}