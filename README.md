# Win10_BrightnessSlider
this app puts a Monitor Brightness icon to on Taskbar Tray. So you can access it with 1 click.
targeting laptops. 

* **supported os**:  win7 , win8 , win10 
* **requirements**: .net4 framework.  (win7 may need to install)  
* **Note For Developers**: code version is  first working version (maybe 1.01). but **executable is always up to date**

**Donate Me:** [DonateMe](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/DonateMe.md)  

**Discord:** [Discord](https://discordapp.com/channels/484323520671907840) 

**Download Link**   [All Versions](https://github.com/blackholeearth/Win10_BrightnessSlider/releases)


#### Features

* Supports ddc/ci monitors
* Seperate Sliders For Multiple Monitors
* Volume like Slider to Change Monitor Brightness
* Option to Run At Startup
* Ability to *"Rescan/Detect Monitor"* after a Monitor Plugged in/out

#### ScreenShots

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss1.jpg?raw=true)

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss2.jpg?raw=true)

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss3.jpg?raw=true)


#### NOTES   
* v1.4 is most stable. also you can test the newest version and report here.
* if slider working. but suddenly (you plug/unplug monitor/MirrorScreen in any way) then screen act up weird for second.
 you CAN get error while trying to change birghtness, you gotta press "Detect monitor".  
 
* if it doesn't work  
  a) try install/update your graphic driver  
  b) try enable ddci on monitor

 
#### ChangeLog

v1.7.5
 * fixing: null check  richscreen.getbrighness>get_physicalmonitor()
 
v1.7.4
 * added:  sun image near each slider shows name on hover
 * fixed: ``(ddci problem )slider doesnt change birghtness at first time, i have to rightclick trayIcon > Press "detect Monitor"``  
 
v1.7.3
* added:  Check For Updates , shows in rightclick menu.
* fixed: new monitor populator
* fixed: ddci brightness displaying -1 (may not work on all ddci monitors)
* fixed: blurry text high dpi  
* fixed: ``i got 3 screens, but i have 5 sliders``. (slider popualtion method changed )
 
v1.04 [most stable]
* added: author page to  menu item  that shows version no.
* trying to fix: fallback doesnt handle management not supported exception.

v1.02

* added: seperately change brightness of multiple monitors.
* added: supports setting Brighness on ddc/ci Monitors(at startup, it may show -1,  )
* fixed: slider showing itself on second screen onhide 
* fixed: popup stays under taskbar, if taskbar is autoHiding  

v1.01

* fixed: slider wasn't positioning itself according to taskbar position (Top Or Bottom Or Left Or Right of Screen)

