echo "==> Uninstalling the app from the device..."
adb uninstall com.altom.TrashCat

echo "==> Installing the app on the device..."
adb install app/TrashCat.apk

echo "==> Setup ADB reverse port forwarding..."
adb reverse --remove-all 
adb reverse tcp:13000 tcp:13000

echo " Start the app "

adb shell am start -n com.altom.TrashCat/com.unity3d.player.UnityPlayerActivity


echo "==> Wait for app to start"
sleep 5
cd TestsAltTrashCatCSharp

echo "==> Restore test project and run tests"
dotnet test  -- NUnit.TestOutputXml = "TestAlttrashCSharp"

echo "==> Kill app"
adb shell am force-stop com.altom.TrashCat

echo "remove reverse ports"
adb reverse --remove-all