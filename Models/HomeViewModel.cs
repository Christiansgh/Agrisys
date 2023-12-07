using Agrisys.Utils;

namespace Agrisys.Models;

public class HomeViewModel {
    public int HomeViewModelId { get; set; }

    public string? LogMessages { get; set; }

    public double? SiloAmount { get; set; }
    public State? SiloState { get; set; }

    public double? MixerAmount { get; set; }
    public State? MixerState { get; set; }

    public State? HatchOneState { get; set; }

    public double? DistributorAmount { get; set; }
    public State? DistributorState { get; set; }

    public State? HatchTwoState { get; set; }

    public double? FanAmount { get; set; }
    public State? FanState { get; set; }

    public double? Pressure { get; set; }

    public string? TargetId { get; set; }
}
