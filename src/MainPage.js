import './MainPage.css';
import axios, { Axios } from 'axios';
import { useEffect } from 'react';
import { Link,Routes,Route,Outlet} from "react-router-dom";
import Authorization from './Authorization';
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
                            var divCard = document.createElement('div');
                            divCard.setAttribute('class','cardDiv');
                            var img = document.createElement('img');
                            img.setAttribute('class','imgCard');
                            img.src = iter['uriPhoto'];
                            var title = document.createElement('h3');
                            title.textContent = iter['title'] + ' ' + iter['model'];
                            var price  = document.createElement('h4');
                            price.textContent = iter['price'] + 'грн';
                            var btnBuy = document.createElement('button');
                            btnBuy.textContent = 'Buy';
                            btnBuy.addEventListener('click',()=>{
                                console.log(iter['id']);
                            });


                            divCard.append(img);
                            divCard.append(title);
                            divCard.append(price);
                            divCard.append(btnBuy);
                            mainDiv.append(divCard);
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
                <h1 id='NameMarket'>M1n1_MarKet</h1>
                <input id='searchtext' type="search" placeholder='Search....' />
                <button id='buttonSearch' onClick={() => {
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
                        var mainDiv = document.getElementById('MainDiv');
                        mainDiv.innerHTML = "";
                        for (const iter of product['data']['value']) {
                            var divCard = document.createElement('div');
                            divCard.setAttribute('class','cardDiv');
                            var img = document.createElement('img');
                            img.setAttribute('class','imgCard');
                            img.src = iter['uriPhoto'];
                            var title = document.createElement('h3');
                            title.textContent = iter['title'] + ' ' + iter['model'];
                            var price  = document.createElement('h4');
                            price.textContent = iter['price'] + 'грн';
                            var btnBuy = document.createElement('button');
                            btnBuy.textContent = 'Buy';
                            btnBuy.addEventListener('click',()=>{
                                console.log(iter['id']);
                            });


                            divCard.append(img);
                            divCard.append(title);
                            divCard.append(price);
                            divCard.append(btnBuy);
                            mainDiv.append(divCard);
                        }
                    });
                }}>Confirm</button>
                <Link target='_blank' to='/Authorization.js'>Sign In</Link>
                <Outlet/>
                {/* <a target='_blank' href="/Authorization.js">Sign IN</a> */}
                <Routes>
                    <Route path='/Authorization.js' element={<Authorization/>}></Route>
                </Routes>
                {/* <button onClick={()=>{
                    console.log('click');
                    // window.open('http://localhost:3000/Authorization');
                    window.location.assign('http://localhost:3000/Authorization');
                }}>Sign In</button> */}
                
            </div>
            <div id='MenuDiv'>
                <div id='menuDivInner'></div>
                <div id="MainDiv"></div>
            </div>
        </div>
    );
}
export default MainPage;
