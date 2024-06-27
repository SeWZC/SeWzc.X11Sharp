using System.Drawing;

namespace SeWzc.X11Sharp.Internal;

internal enum NotifyMode
{
    NotifyNormal = 0,
    NotifyGrab = 1,
    NotifyUngrab = 2,
    NotifyWhileGrabbed = 3,
}

internal enum NotifyDetail
{
    NotifyAncestor = 0,
    NotifyVirtual = 1,
    NotifyInferior = 2,
    NotifyNonlinear = 3,
    NotifyNonlinearVirtual = 4,
    NotifyPointer = 5,
    NotifyPointerRoot = 6,
    NotifyDetailNone = 7,
}

internal enum CirculationRequest
{
    PlaceOnTop = 0,
    PlaceOnBottom = 1,
}

internal enum ColorMapNotification
{
    ColorMapUninstalled = 0,
    ColorMapInstalled = 1,
}