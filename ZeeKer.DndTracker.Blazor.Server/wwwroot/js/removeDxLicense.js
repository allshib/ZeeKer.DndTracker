window.clearDxLicenseTag = () => {
    const dxLicenseTag = document.querySelector('dx-license');
    if (dxLicenseTag) {
        dxLicenseTag.setAttribute('version', '');
    }

    const innerDiv = dxLicenseTag.querySelectorAll('div');

    innerDiv.forEach(di => {
        di.click();
    })

    //if (innerDiv) {
    //    const spans = innerDiv.querySelectorAll('span');
    //    console.log(spans);
    //    spans.forEach(span => {
    //        span.style = 'none !important';
    //    });

    //    const link = innerDiv.querySelector('a');
    //    console.log(link);
        
    //}
};