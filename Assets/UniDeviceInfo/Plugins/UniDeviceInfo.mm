extern "C"
{
    char* MakeStringCopy (const char* string)
    {
        if (string == NULL)
            return NULL;
        
        char* res = (char*)malloc(strlen(string) + 1);
        strcpy(res, string);
        return res;
    }
    
    // アプリのバージョンを取得する(ユーザーに見える情報)
    char* GetVersionName_()
    {
        NSString *buildNo = [[[NSBundle mainBundle] infoDictionary] objectForKey:@"CFBundleShortVersionString"];
        return MakeStringCopy( [buildNo UTF8String] );
    }

    // アプリのビルドバージョンを取得する(ユーザーには見えない)
    char* GetBuildVersionName_()
    {
        NSString *buildNo = [[[NSBundle mainBundle] infoDictionary] objectForKey:@"CFBundleVersion"];
        return MakeStringCopy( [buildNo UTF8String] );
    }
    
    // アプリのモデル名を取得 Ex: iPhone, iPod, iPad
    char* GetModelName_(){
        return MakeStringCopy ( [[UIDevice currentDevice].model UTF8String] );
    }
    
    // 脱獄しているかどうか
    bool IsJailBreakBroken_ () {
        
#if !(TARGET_IPHONE_SIMULATOR)
        // path and url scheme check
        if ([[NSFileManager defaultManager] fileExistsAtPath:@"/Applications/Cydia.app"] ||
            [[NSFileManager defaultManager] fileExistsAtPath:@"/Library/MobileSubstrate/MobileSubstrate.dylib"] ||
            [[NSFileManager defaultManager] fileExistsAtPath:@"/bin/bash"] ||
            [[NSFileManager defaultManager] fileExistsAtPath:@"/usr/sbin/sshd"] ||
            [[NSFileManager defaultManager] fileExistsAtPath:@"/etc/apt"] ||
            [[NSFileManager defaultManager] fileExistsAtPath:@"/private/var/lib/apt/"] ||
            [[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString:@"cydia://package/com.example.package"]])  {
            return YES;
        }
        // file open check
        FILE *f = NULL ;
        if ((f = fopen("/bin/bash", "r")) ||
            (f = fopen("/Applications/Cydia.app", "r")) ||
            (f = fopen("/Library/MobileSubstrate/MobileSubstrate.dylib", "r")) ||
            (f = fopen("/usr/sbin/sshd", "r")) ||
            (f = fopen("/etc/apt", "r")))  {
            fclose(f);
            return YES;
        }
        fclose(f);
        // write check
        NSError *error;
        NSString *stringToBeWritten = @"This is a test.";
        [stringToBeWritten writeToFile:@"/private/jailbreak.txt" atomically:YES encoding:NSUTF8StringEncoding error:&error];
        [[NSFileManager defaultManager] removeItemAtPath:@"/private/jailbreak.txt" error:nil];
        if(error == nil) {
            return YES;
        }
#endif
        return NO;
    }
    
}
