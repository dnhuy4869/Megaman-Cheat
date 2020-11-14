using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MegamanCheat
{
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		SoundPlayer sp_active = default(SoundPlayer);
		SoundPlayer sp_hover = default(SoundPlayer);
		SoundPlayer sp_megaman = default(SoundPlayer);

		private bool _IsInjected;
		public bool IsInjected
		{
			get { return _IsInjected; }
			set { _IsInjected = value; OnPropertyChanged(); }
		}

		private bool _IsOneHitCreep;
		public bool IsOneHitCreep
		{
			get { return _IsOneHitCreep; }
			set { _IsOneHitCreep = value; OnPropertyChanged(); }
		}

		private bool _IsOneHitBoss;
		public bool IsOneHitBoss
		{
			get { return _IsOneHitBoss; }
			set { _IsOneHitBoss = value; OnPropertyChanged(); }
		}

		private bool _IsFullLife;
		public bool IsFullLife
		{
			get { return _IsFullLife; }
			set { _IsFullLife = value; OnPropertyChanged(); }
		}

		private bool _IsImmortal;
		public bool IsImmortal
		{
			get { return _IsImmortal; }
			set { _IsImmortal = value; OnPropertyChanged(); }
		}

		private Visibility _IsShow;
		public Visibility IsShow
		{
			get { return _IsShow; }
			set { _IsShow = value; OnPropertyChanged(); }
		}


		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
			FirstLoad();
		}

		#region Methods
		private void FirstLoad()
		{
			sp_active = new SoundPlayer(Properties.Resources.hover_2);
			sp_hover = new SoundPlayer(Properties.Resources.hover);
			sp_megaman = new SoundPlayer(Properties.Resources.megaman);
			IsShow = Visibility.Hidden;
		}

		private void PlaySoundActive()
		{
			sp_active.Play();
		}

		private void PlaySoundHover()
		{
			sp_hover.Play();
		}
		#endregion

		#region Events
		private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			this.DragMove();
		}

		private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
		{
			IsShow = Visibility.Visible;
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			IsInjected = !IsInjected;
			PlaySoundActive();
		}

		private void Image_MouseEnter(object sender, MouseEventArgs e)
		{
			if (IsInjected == false)
			{
				PlaySoundHover();
			}
		}

		private void Image_MouseDown_OneHitCreep(object sender, MouseButtonEventArgs e)
		{
			IsOneHitCreep = !IsOneHitCreep;
			PlaySoundActive();
		}

		private void Image_MouseEnter_OneHitCreep(object sender, MouseEventArgs e)
		{
			if (IsOneHitCreep == false)
			{
				PlaySoundHover();
			}
		}

		private void Image_MouseDown_OneHitBoss(object sender, MouseButtonEventArgs e)
		{
			IsOneHitBoss = !IsOneHitBoss;
			PlaySoundActive();
		}

		private void Image_MouseEnter_OneHitBoss(object sender, MouseEventArgs e)
		{
			if (IsOneHitBoss == false)
			{
				PlaySoundHover();
			}
		}

		private void Image_MouseDown_FullLife(object sender, MouseButtonEventArgs e)
		{
			IsFullLife = !IsFullLife;
			PlaySoundActive();
		}

		private void Image_MouseEnter_FullLife(object sender, MouseEventArgs e)
		{
			if (IsFullLife == false)
			{
				PlaySoundHover();
			}
		}

		private void Image_MouseDown_Immortal(object sender, MouseButtonEventArgs e)
		{
			IsImmortal = !IsImmortal;
			PlaySoundActive();
		}

		private void Image_MouseEnter_Immortal(object sender, MouseEventArgs e)
		{
			if (IsImmortal == false)
			{
				PlaySoundHover();
			}
		}

		private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			sp_megaman.Play();
			IsInjected = true;
			IsOneHitCreep = !IsOneHitCreep;
			IsOneHitBoss = !IsOneHitBoss;
			IsFullLife = !IsFullLife;
			IsImmortal = !IsImmortal;
		}

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Close();
		}

		private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			IsShow = Visibility.Hidden;
		}
		#endregion
	}
}
