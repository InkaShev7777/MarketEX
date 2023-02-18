import './MainPage.css';
import axios, { Axios } from 'axios';
import { useEffect } from 'react';
function MainPage() {
    useEffect(() => {
        //
        //      Get all list category
        //

        axios({
            method: 'get',
            url: 'https://localhost:7031/api/ControllerClass/GetAllCategory',
            dataType: "dataType",
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json'
            }
        }).then(data => {
            console.log(data);
            var divMenu = document.getElementById('menuDivInner');
            divMenu.innerHTML = "";
            for (const iterator of data['data']['value']) {
                var h3 = document.createElement('h3');
                h3.textContent = iterator['title'];
                //
                //      Click in category
                //
                h3.addEventListener('click', () => {
                    console.log(iterator['id']);

                    //
                    //      get list product by category id
                    //

                    axios({
                        method: 'get',
                        url: `https://localhost:7031/api/ControllerClass/GetProductsByID?id=${iterator['id']}`,
                        dataType: "dataType",
                        headers: {
                            'Accept': '*/*',
                            'Content-Type': 'application/json'
                        }
                    }).then(product => {
                        console.log(product);

                        var mainDiv = document.getElementById('MainDiv');
                        mainDiv.innerHTML = "";
                        for (const iter of product['data']['value']) {
                            var img = document.createElement('img');
                            img.src = iter['uriPhoto'];
                            mainDiv.append(img);
                        }
                    });


                });
                divMenu.append(h3);
            }
            return data;
        });
        return undefined;
    });
    return (
        <div>
            <div id="SearchDiv">
                <input id='searchtext' type="search" placeholder='Search....' />
                <button onClick={() => {
                    //
                    //      Search
                    //
                    axios({
                        method: 'get',
                        url: `https://localhost:7031/api/ControllerClass/SearchProduct?text=${document.getElementById('searchtext').value}`,
                        dataType: "dataType",
                        headers: {
                            'Accept': '*/*',
                            'Content-Type': 'application/json'
                        }
                    }).then(product => {
                        console.log(product);

                        var mainDiv = document.getElementById('MainDiv');
                        mainDiv.innerHTML = "";
                        for (const iter of product['data']['value']) {
                            var img = document.createElement('img');
                            img.src = iter['uriPhoto'];
                            mainDiv.append(img);
                        }
                    });
                }}>Confirm</button>
            </div>
            <div id='MenuDiv'>
                <div id='menuDivInner'></div>
                <div id="MainDiv"></div>
            </div>
        </div>
    );
}
export default MainPage;
