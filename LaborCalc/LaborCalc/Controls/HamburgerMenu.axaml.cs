using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;

namespace LaborCalc.Views;

[PseudoClasses(":normal")]
public class HamburgerMenu : TabControl, IStyleable
{
    private SplitView? _splitView;

    public static readonly StyledProperty<IBrush?> PaneBackgroundProperty =
        SplitView.PaneBackgroundProperty.AddOwner<HamburgerMenu>();

    public IBrush? PaneBackground
    {
        get => GetValue(PaneBackgroundProperty);
        set => SetValue(PaneBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush?> ContentBackgroundProperty =
        AvaloniaProperty.Register<HamburgerMenu, IBrush?>(nameof(ContentBackground));

    public IBrush? ContentBackground
    {
        get => GetValue(ContentBackgroundProperty);
        set => SetValue(ContentBackgroundProperty, value);
    }

    public static readonly StyledProperty<int> ExpandedModeThresholdWidthProperty =
        AvaloniaProperty.Register<HamburgerMenu, int>(nameof(ExpandedModeThresholdWidth), 1008);

    public int ExpandedModeThresholdWidth
    {
        get => GetValue(ExpandedModeThresholdWidthProperty);
        set => SetValue(ExpandedModeThresholdWidthProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _splitView = e.NameScope.Find<SplitView>("PART_NavigationPane");
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == BoundsProperty && _splitView is not null)
        {
            var (oldBounds, newBounds) = change.GetOldAndNewValue<Rect>();
            EnsureSplitViewMode(oldBounds, newBounds);
        }
    }

    private void EnsureSplitViewMode(Rect oldBounds, Rect newBounds)
    {
        if (_splitView is not null)
        {
            var threshold = ExpandedModeThresholdWidth;

            if (newBounds.Width >= threshold && oldBounds.Width < threshold)
            {
                _splitView.DisplayMode = SplitViewDisplayMode.Inline;
                _splitView.IsPaneOpen = true;
            }
            else if (newBounds.Width < threshold && oldBounds.Width >= threshold)
            {
                _splitView.DisplayMode = SplitViewDisplayMode.Overlay;
                _splitView.IsPaneOpen = false;
            }
        }
    }

    #region

    Type IStyleable.StyleKey => typeof(HamburgerMenu);

    public HamburgerMenu()
    {
        PseudoClasses.Add(":normal");
        this.GetObservable(SelectedContentProperty).Subscribe(OnContentChanged);
    }

    private void OnContentChanged(object obj)
    {
        if (AnimateOnChange)
        {
            PseudoClasses.Remove(":normal");
            PseudoClasses.Add(":normal");
        }
    }

    public bool AnimateOnChange
    {
        get => GetValue(AnimateOnChangeProperty);
        set => SetValue(AnimateOnChangeProperty, value);
    }

    public static readonly StyledProperty<bool> AnimateOnChangeProperty =
        AvaloniaProperty.Register<HamburgerMenu, bool>(nameof(AnimateOnChange), true);

    #endregion
}