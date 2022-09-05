const uri = 'https://api.iotsol.net/api/GetIMEIDataServicesByIMEIAndCompany';

async function getInfo() {
    const item = {
        "IMEI": "354330030646882",
        "CompanyID": 10
    };

    const headers = {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'POST,PATCH,OPTIONS'
    }

    await fetch(uri, {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(item),
    })
        .then(response => response.json())
        .then(response => console.log('Success:', response))
        .catch(error => console.error('Unable to add item.', error));
}