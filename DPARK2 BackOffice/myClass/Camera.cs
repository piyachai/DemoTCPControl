using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;

using AForge.Video;
using AForge.Video.DirectShow;



    public class Camera
    {
        public Camera(int camDevice)
        {
           // webCamStart(camDevice);
        }

        private VideoCaptureDevice videoSource = null;
        private FilterInfoCollection videoDevices;


        public delegate void camNewFrame_Delegate(Bitmap frame); // 

        public event camNewFrame_Delegate camNewFrameEvent;
        
        //close the device safely
        public void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }
        private void CameraStart(int camDevice)
        {
           
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0) { return; }
                videoSource = new VideoCaptureDevice(videoDevices[camDevice].MonikerString);
                videoSource.NewFrame += delegate(object sender, NewFrameEventArgs eventArgs)
                                        {
                                            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
                                            camNewFrameEvent(img);
                                        };
                CloseVideoSource();
                videoSource.DesiredFrameSize = new Size(320, 240);
                videoSource.Start();
  
        }
        public void CameraStart(string url, string username, string passwd)
            // streaming
        {// create MJPEG video source

                MJPEGStream stream = new MJPEGStream(
                        "rstp://admin:admin@192.168.10.108:554/cam/realmonitor?channel=2&subtype=1");
                // set event handlers
                stream.NewFrame += delegate(object sender, NewFrameEventArgs eventArgs)
                {
                    Bitmap img = (Bitmap)eventArgs.Frame.Clone();
                    camNewFrameEvent(img);
                };
                // start the video source
                if (!(stream == null))
                    if (stream.IsRunning)
                    {
                        stream.SignalToStop();
                        stream = null;
                    }
               stream.Start( );
		}


    }
