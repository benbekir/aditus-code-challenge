using ADITUS.CodeChallenge.API.Domain.Hardware;

namespace ADITUS.CodeChallenge.API.MockData;

/// <summary>
/// This class is used to store various objects in memory.
/// </summary>
public static class HardwareData
{
  /// <summary>
  /// The reservations that have been made.
  /// </summary>
  public static List<ReservationRequest> Reservations { get; set; } = [];

  /// <summary>
  /// The available scanners.
  /// </summary>
  public static List<Scanner> Scanners { get; set; } = [ new Scanner(), new Scanner(), new Scanner(), new Scanner() ];

  /// <summary>
  /// The available terminals.
  /// </summary>
  public static List<Terminal> Terminals { get; set; } = [ new Terminal(), new Terminal() ];

  /// <summary>
  /// The available turnstiles.
  /// </summary>
  public static List<Turnstile> Turnstiles { get; set; } = [ new Turnstile(), new Turnstile(), new Turnstile() ];
}
