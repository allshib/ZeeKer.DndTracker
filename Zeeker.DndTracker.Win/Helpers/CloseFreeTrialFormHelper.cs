using DevExpress.ExpressApp.Win;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zeeker.DndTracker.Win.Helpers
{
    internal static class CloseFreeTrialFormHelper
    {
        public static void OffAboutForm()
        => typeof(WinWindow)
            .GetField("isAboutFormShow", BindingFlags.NonPublic | BindingFlags.Static)?
            .SetValue(null, true);     
        

        public static void OffFreeTrialForm()
        {
            GlobalFormTracker.Initialize();
            GlobalFormTracker.FormCreated += GlobalFormTracker_FormCreated;
        }

        private static void GlobalFormTracker_FormCreated(Form form)
        {
            if (form is AboutForm12)
            {
                form.Close();
                GlobalFormTracker.FormCreated -= GlobalFormTracker_FormCreated;
            }
        }
    }


    public static class GlobalFormTracker
    {
        private static IntPtr hookId = IntPtr.Zero;
        private static WinEventDelegate procDelegate = new WinEventDelegate(WinEventProc);

        public delegate void FormCreatedHandler(Form form);
        public static event FormCreatedHandler FormCreated;

        public static void Initialize()
        {
            hookId = SetWinEventHook(EVENT_OBJECT_CREATE, EVENT_OBJECT_CREATE, IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        public static void Terminate()
        {
            UnhookWinEvent(hookId);
        }

        private static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (eventType == EVENT_OBJECT_CREATE && idObject == OBJID_WINDOW)
            {
                var form = Control.FromHandle(hwnd) as Form;
                if (form != null)
                {
                    FormCreated?.Invoke(form);
                }
            }
        }

        private const uint EVENT_OBJECT_CREATE = 0x8000;
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const int OBJID_WINDOW = 0x00000000;

        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);
    }



    internal static class CloseFreeTrialFormHelperOld
    {

        public static void OffFreeTrialForm()
        {

            StartFreeTrialFormCheckThread()
                .ContinueWith(x => CloseTrialForm(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private static Task StartFreeTrialFormCheckThread()
        {
            var task = new Task(CheckForms);
            task.Start();
            return task;
        }
        private static void CloseTrialForm()
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form is AboutForm12)
                {
                    form.Close();
                    break;
                }
            }
        }

        private static void CheckForms()
        {
            while (true)
            {
                foreach (var form in Application.OpenForms)
                {
                    if (form is AboutForm12)
                        return;
                }
                Thread.Sleep(1);
            }
        }
    }
}
