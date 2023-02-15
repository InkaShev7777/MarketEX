import './Authorize.css';
function Authoriz(){
    return(
        <div className='mainDiv'>
            <h1>Authorization</h1>
            <input type="text" placeholder="Login"/>
            <input style={{margin:'0px'}} type="password" placeholder="Password"/>
            <button onClick={()=>{
                alert('click');
            }}>Confirm</button>
        </div>
    );
}
export default Authoriz;