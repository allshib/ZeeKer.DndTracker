window.clearDxLicenseTag = () => {
    const dxLicenseTag = document.querySelector('dx-license');
    if (dxLicenseTag) {
        const innerDiv = dxLicenseTag.querySelectorAll('div');
        if (innerDiv) {
            innerDiv.forEach(di => {
                di.click();
            })
        }
    }
    
    

};