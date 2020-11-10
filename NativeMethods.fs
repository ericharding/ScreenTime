module NativeMethods

open System
open System.Runtime.InteropServices
open System.Text

[<Struct; CLIMutable>]
type LastInputInfo = { size: int; dwTime: uint32 }

[<DllImport("user32")>]
extern int GetLastInputInfo(LastInputInfo& lpi)

let idleTime() =
  let mutable lpi = { size = sizeof<LastInputInfo>; dwTime = 0u }
  let result = GetLastInputInfo(&lpi)
  let tc = uint System.Environment.TickCount
  TimeSpan.FromSeconds (float (tc - lpi.dwTime) / 1000.)


[<DllImport("user32")>]
extern IntPtr GetForegroundWindow()

[<DllImport("user32", CharSet=CharSet.Auto)>]
extern IntPtr GetWindowText(IntPtr hwnd, StringBuilder lpString, int maxCount)

let foregroundWindowTitle() =
  let hwnd = GetForegroundWindow()
  let maxLen = 1024;
  let sb = StringBuilder(maxLen)
  GetWindowText(hwnd, sb, maxLen) |> ignore
  sb.ToString()

// foregroundWindowTitle()