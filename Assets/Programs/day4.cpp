#include <iostream>
#include <Employees>
#include <NSA>
#include <eMail>

int main() {
    NSA *nsa = NSA::BribeNSA( 3.50 );
    
    Employees::iterator empIt = Employees.begin();
    while(empIt.next()) {
        nsa->EnableHiddenCameras( (*(empIt.data()))->fullName );
        nsa->EnablePhoneMic( (*(empIt.data()))->fullName );
    }

    while(nsa->monitorVictims()) {
        EMail::ReportSurveillance(nsa);
    }

    return 1;
}