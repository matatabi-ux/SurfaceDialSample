using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace SurfaceDialSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Surface Dial 管理クラス
        /// </summary>
        private RadialController control;

        public MainPage()
        {
            this.InitializeComponent();

            this.control = RadialController.CreateForCurrentView();

            // オリジナルのメニューを追加
            var icon = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/CatHand.png"));
            var item = RadialControllerMenuItem.CreateFromIcon("Sample", icon);
            this.control.Menu.Items.Add(item);

            // イベントの購読
            this.control.ButtonClicked += this.OnButtonClicked;
            this.control.RotationChanged += this.OnRotationChanged;
        }

        /// <summary>
        /// Surface Dial ボタンクリックイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="args">イベント引数</param>
        private void OnButtonClicked(RadialController sender, RadialControllerButtonClickedEventArgs args)
        {
            this.DialToggle.IsOn = !this.DialToggle.IsOn;
        }

        /// <summary>
        /// Surface Dial 回転イベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="args">イベント引数</param>
        private void OnRotationChanged(RadialController sender, RadialControllerRotationChangedEventArgs args)
        {
            this.DialSlider.Value = Math.Max(0d, Math.Min(this.DialSlider.Value + args.RotationDeltaInDegrees, 100d));
        }
    }
}
