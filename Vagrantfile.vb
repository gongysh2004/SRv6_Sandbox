# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure("2") do |config|
        # Node R1 configuration
	config.vm.define "hosta" do |hosta|
		hosta.vm.box = "srouting/srv6-net-prog"
		hosta.vm.box_version = "0.4.14"
		hosta.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		hosta.vm.network "private_network", ip: "10.0.0.1", virtualbox__intnet: "netv4a"
		hosta.vm.provider "virtualbox" do |virtualbox|
			virtualbox.memory = "256"
			virtualbox.customize ['modifyvm', :id, '--nictrace2', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile2', 'tracea.pcap']
			virtualbox.customize ['modifyvm', :id, '--cableconnected1', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected2', 'on']
		end
		hosta.vm.provision "shell", path: "config/config_a.sh"
        end
        
	config.vm.define "hostb" do |hostb|
		hostb.vm.box = "srouting/srv6-net-prog"
		hostb.vm.box_version = "0.4.14"
		hostb.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		hostb.vm.network "private_network", ip: "10.0.1.1", virtualbox__intnet: "netv4b"
		hostb.vm.provider "virtualbox" do |virtualbox|
			virtualbox.memory = "256"
			virtualbox.customize ['modifyvm', :id, '--nictrace2', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile2', 'traceb.pcap']
			virtualbox.customize ['modifyvm', :id, '--cableconnected1', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected2', 'on']
		end
		hostb.vm.provision "shell", path: "config/config_b.sh"
        end
        
	# Node R1 configuration
	config.vm.define "r1" do |r1|
		r1.vm.box = "srouting/srv6-net-prog"
		r1.vm.box_version = "0.4.14"
		r1.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		r1.vm.network "private_network", ip: "10.0.0.2", virtualbox__intnet: "netv4a"
		r1.vm.network "private_network", ip: "2001:12::1",netmask: "64", virtualbox__intnet: "net12"

		r1.vm.provider "virtualbox" do |virtualbox|
			virtualbox.memory = "256"
			virtualbox.customize ['modifyvm', :id, '--nictrace2', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile2', 'trace1.pcap']
			virtualbox.customize ['modifyvm', :id, '--nictrace3', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile3', 'trace12.pcap']
			virtualbox.customize ['modifyvm', :id, '--cableconnected1', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected2', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected3', 'on']

		end
		r1.vm.provision "shell", path: "config/config_r1.sh"
	end

	# Node R2 configuration
	config.vm.define "r2" do |r2|
		r2.vm.box = "srouting/srv6-net-prog"
		r2.vm.box_version = "0.4.14"
                r2.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		r2.vm.network "private_network", ip: "2001:12::2",netmask: "64", virtualbox__intnet: "net12"
		r2.vm.network "private_network", ip: "2001:23::1",netmask: "64", virtualbox__intnet: "net23"
		r2.vm.network "private_network", ip: "2001:a::1",netmask: "64", virtualbox__intnet: "netserver1"

		r2.vm.provider "virtualbox" do |virtualbox|
			virtualbox.memory = "256"
			virtualbox.cpus = "1"
			virtualbox.customize ['modifyvm', :id, '--nictrace2', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile2', 'trace2.pcap']
			virtualbox.customize ['modifyvm', :id, '--nictrace3', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile3', 'trace21.pcap']
			virtualbox.customize ['modifyvm', :id, '--nictrace4', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile4', 'trace22.pcap']
			virtualbox.customize ['modifyvm', :id, '--cableconnected1', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected2', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected3', 'on']
		end
		r2.vm.provision "shell", path: "config/config_r2.sh"
	end

        # Node R3 configuration
        config.vm.define "r3" do |r3|
                r3.vm.box = "srouting/srv6-net-prog"
                r3.vm.box_version = "0.4.14"
		r3.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
		r3.vm.network "private_network", ip: "10.0.1.2", virtualbox__intnet: "netv4b"
                r3.vm.network "private_network", ip: "2001:23::2",netmask: "64", virtualbox__intnet: "net23"
		r3.vm.network "private_network", ip: "2001:b::1",netmask: "64", virtualbox__intnet: "netserver2"
                r3.vm.provider "virtualbox" do |virtualbox|
			virtualbox.memory = "256"
			virtualbox.customize ['modifyvm', :id, '--nictrace2', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile2', 'trace3.pcap']
			virtualbox.customize ['modifyvm', :id, '--nictrace3', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile3', 'trace31.pcap']
			virtualbox.customize ['modifyvm', :id, '--nictrace4', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile4', 'trace32.pcap']

                        virtualbox.customize ['modifyvm', :id, '--cableconnected1', 'on']
                        virtualbox.customize ['modifyvm', :id, '--cableconnected2', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected3', 'on']
			virtualbox.customize ['modifyvm', :id, '--cableconnected4', 'on']

                end
	        r3.vm.provision "shell", path: "config/config_r3.sh"
        end
        # server1 configuration
        config.vm.define "server1" do |server1|
                server1.vm.box = "srouting/srv6-net-prog"
                server1.vm.box_version = "0.4.14"
                server1.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
                server1.vm.network "private_network", ip: "2001:a::2",netmask: "64", virtualbox__intnet: "netserver1"
                server1.vm.provider "virtualbox" do |virtualbox|
			virtualbox.memory = "256"
			virtualbox.customize ['modifyvm', :id, '--nictrace2', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile2', 'traceserver1.pcap']
                        virtualbox.customize ['modifyvm', :id, '--cableconnected1', 'on']
                        virtualbox.customize ['modifyvm', :id, '--cableconnected2', 'on']
                end
		server1.vm.provision "shell", path: "config/config_server1.sh"
        end

        # server2 configuration
        config.vm.define "server2" do |server2|
                server2.vm.box = "srouting/srv6-net-prog"
                server2.vm.box_version = "0.4.14"
                server2.vm.synced_folder(".", nil, :disabled => true, :id => "vagrant-root")
                server2.vm.network "private_network", ip: "2001:b::2",netmask: "64", virtualbox__intnet: "netserver2"
                server2.vm.provider "virtualbox" do |virtualbox|
			virtualbox.memory = "256"
			virtualbox.customize ['modifyvm', :id, '--nictrace2', 'on'] 
			virtualbox.customize ['modifyvm', :id, '--nictracefile2', 'traceserver2.pcap']
                        virtualbox.customize ['modifyvm', :id, '--cableconnected1', 'on']
                        virtualbox.customize ['modifyvm', :id, '--cableconnected2', 'on']
                end
	        server2.vm.provision "shell", path: "config/config_server2.sh"
        end
end
