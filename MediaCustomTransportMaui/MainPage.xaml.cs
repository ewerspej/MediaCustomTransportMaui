using CommunityToolkit.Maui.Core.Primitives;

namespace MediaCustomTransportMaui;

public partial class MainPage : ContentPage
{
    private bool _isPlaying;
    public bool IsPlaying
    {
        get => _isPlaying;
        set
        {
            if (value == _isPlaying) return;
            _isPlaying = value;
            OnPropertyChanged();
        }
    }

    public MainPage()
    {
        InitializeComponent();

        MediaPlayer.PropertyChanged += MediaPlayer_PropertyChanged;
    }

    private void MediaPlayer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MediaPlayer.CurrentState))
        {
            IsPlaying = MediaPlayer.CurrentState == MediaElementState.Playing;
        }
    }

    private void OnPlayButtonClicked(object sender, EventArgs e)
    {
        MediaPlayer.Play();
    }

    private void OnPauseButtonClicked(object sender, EventArgs e)
    {
        MediaPlayer.Pause();
    }

    private void OnSetPositionClicked(object sender, EventArgs e)
    {
        MediaPlayer.SeekTo(TimeSpan.FromSeconds(120.0));
    }
}

