//
//	  UnityOSC - Example of usage for OSC receiver
//
//	  Copyright (c) 2012 Jorge Garcia Martin
//
// 	  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// 	  documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// 	  the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
// 	  and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// 	  The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// 	  of the Software.
//
// 	  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// 	  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// 	  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// 	  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// 	  IN THE SOFTWARE.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;

public class oscControl : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	private float randVal=0f;
	public GameObject cube;
	private String msg="";
    private int curCount = 0;
	// Script initialization
	void Start() {	
		OSCHandler.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
		cube = GameObject.Find ("Cube");
	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {
		
		// OSCHandler.Instance.UpdateLogs();

       float mouseX = OSCHandler.Instance.getMouseX() * 5;
       float mouseY = OSCHandler.Instance.getMouseY() * 5;
       
    //    cube.Positi.Set(100, mouseY, cube.transform.position.z);
    //    print(cube.transform.position);
        float dx = mouseX - cube.transform.position.x;
        float dy = mouseY - cube.transform.position.z;
        
         
       cube.transform.Translate(dx, 0, dy);

		//servers = OSCHandler.Instance.Servers;
        // OSCHandler.UpdateLogs();
        //print("update");
        
        /**
		foreach (KeyValuePair<string, ServerLog> item in servers) {
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
            //print(item.Value.log.Count);
			if (item.Value.log.Count > curCount) {
				int lastPacketIndex = item.Value.packets.Count - 1;
					
                    /**
				UnityEngine.Debug.Log (String.Format ("SERVER: {0} ADDRESS: {1} VALUE : {2}", 
					                                    item.Key, // Server name
					                                    item.Value.packets [lastPacketIndex].Address, // OSC address
					                                    item.Value.packets [lastPacketIndex].Data [0].ToString ())); //First data value
                                                        */
                                                        
           /*                                             
                curCount++;                                                        
				
			}
		} */
			
	}
}