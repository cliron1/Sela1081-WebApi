const url = 'https://localhost:7133/prods';

document.querySelector('#btn')
.addEventListener('click', e=>{
    fetch(url)
        .then(r=> r.json())
        .then(data => console.log(data));
});

document.querySelector('#btnAdd')
.addEventListener('click', e=>{
    const payload = {
        id: 5,
        name: 'Monitor'
    };
    const req = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    };
    fetch(url, req)
        .then(r=> console.log('well done'));
})