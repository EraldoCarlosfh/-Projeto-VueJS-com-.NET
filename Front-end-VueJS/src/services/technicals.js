import{ http } from './config'

export default {    
    list:() =>{
        return http.get('Technical')
        
    },
    save:(usuario) =>{
        return http.post('Technical',usuario)     
    },
    delete:(id) =>{
        return http.delete('Technical',id)     
    }
}